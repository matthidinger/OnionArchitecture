using System.Web;
using Core;
using Core.Domain;
using Core.Services;
using Core.Services.Impl;
using DependencyResolution;
using Infrastructure.EntityFramework;
using Infrastructure.Services;
using Microsoft.Practices.Unity;
using UI.Services;

[assembly: PreApplicationStartMethod(typeof(DependencyRegistrar), "RegisterAllDependencies")]

namespace DependencyResolution
{
    public static class DependencyRegistrar
    {
        public static void RegisterAllDependencies()
        {
            var container = new UnityContainer()
                .RegisterType<IDataContext, EfDataContext>()
                .RegisterType<IShoppingCartProcessor, ShoppingCartProcessor>()
                .RegisterType<IUserSession, HttpUserSession>()
                .RegisterType<IShippingService, ShippingServiceAdapter>()
                .RegisterType<IInventoryService, InventoryServiceAdapter>()
                .RegisterType<ILogger, Log4NetLogger>()
                .RegisterType<IProductVMMapper, ProductMapper>()
                .RegisterType<IOrderProcessor, OrderProcessorAdapter>();


            // Set Unity as the Service Locator Provider
            ServiceLocator.SetServiceLocator(() => new UnityServiceLocator(container));
        }
    }
}