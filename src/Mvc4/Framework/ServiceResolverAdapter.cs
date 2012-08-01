using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Mvc4.Framework
{
    public class ServiceResolverAdapter : IDependencyResolver
    {
        private readonly System.Web.Mvc.IDependencyResolver _dependencyResolver;

        public ServiceResolverAdapter(System.Web.Mvc.IDependencyResolver dependencyResolver)
        {
            if (dependencyResolver == null) throw new ArgumentNullException("dependencyResolver");
            _dependencyResolver = dependencyResolver;
        }

        public object GetService(Type serviceType)
        {
            return _dependencyResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _dependencyResolver.GetServices(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            
        }
    }

    public static class ServiceResolverExtensions
    {
        public static IDependencyResolver ToServiceResolver(this System.Web.Mvc.IDependencyResolver dependencyResolver)
        {
            return new ServiceResolverAdapter(dependencyResolver);
        }
    }
}