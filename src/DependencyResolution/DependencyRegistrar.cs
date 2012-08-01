using System.Web;
using Core;
using Core.Domain;
using Core.Services;
using Core.Services.Impl;
using DependencyResolution;
using Infrastructure.EntityFramework;
using Infrastructure.Services;
using Ninject.Web.Common;
using UI.Services;
using Ninject;

[assembly: PreApplicationStartMethod(typeof(DependencyRegistrar), "RegisterAllDependencies")]

namespace DependencyResolution
{
    public static class DependencyRegistrar
    {
        public static void RegisterAllDependencies()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataContext>().To<EfDataContext>().InRequestScope();
            kernel.Bind<IShoppingCartProcessor>().To<ShoppingCartProcessor>();
            kernel.Bind<IUserSession>().To<HttpUserSession>();
            kernel.Bind<IShippingService>().To<ShippingServiceAdapter>();
            kernel.Bind<IInventoryService>().To<InventoryServiceAdapter>();
            kernel.Bind<ILogger>().To<Log4NetLogger>();
            kernel.Bind<IOrderProcessor>().To<OrderProcessorAdapter>();

            // Set Unity as the Service Locator Provider
            ServiceLocator.SetServiceLocator(() => new NinjectServiceLocator(kernel));
        }
    }
}