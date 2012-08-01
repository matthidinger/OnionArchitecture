using System;
using System.Collections.Generic;
using Core;
using Ninject;

namespace DependencyResolution
{
    public class NinjectServiceLocator : IServiceLocator
    {
        private readonly IKernel _kernel;

        public NinjectServiceLocator(IKernel kernel)
        {
            _kernel = kernel;
        }

        public T GetInstance<T>()
        {
            try
            {
                return _kernel.Get<T>();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Dependency resolution failed", ex);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public object GetInstance(Type type)
        {
            try
            {
                return _kernel.Get(type);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Dependency resolution failed", ex);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetAll(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public IEnumerable<T> GetAll<T>()
        {
            return _kernel.GetAll<T>();
        }
    }
}