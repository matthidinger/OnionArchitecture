using Core;
using Core.Domain;
using Core.Services;
using Core.Services.Impl;
using Infrastructure.EntityFramework;
using Infrastructure.Services;
using UI.Services;
using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;

[assembly: WebActivator.PreApplicationStartMethod(typeof(DependencyResolution.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(DependencyResolution.App_Start.NinjectWebCommon), "Stop")]

namespace DependencyResolution.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDataContext>().To<EfDataContext>().InRequestScope();
            kernel.Bind<IUserSession>().To<HttpUserSession>();
            kernel.Bind<IShippingService>().To<AcmeShippingServiceAdapter>();
            kernel.Bind<IInventoryService>().To<ContosoInventoryServiceAdapter>();
            kernel.Bind<ILogger>().To<Log4NetLogger>();
            kernel.Bind<IOrderProcessor>().To<PayPalOrderProcessor>();
            kernel.Bind<IShoppingCartProcessor>().To<ShoppingCartProcessor>();

            ServiceLocator.SetServiceLocator(() => new NinjectServiceLocator(kernel));
        }        
    }
}
