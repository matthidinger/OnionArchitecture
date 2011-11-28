using System;
using Core;
using Microsoft.Practices.Unity;

namespace DependencyResolution
{
    public class UnityServiceLocator : IServiceLocator
    {
        private readonly IUnityContainer _container;

        public UnityServiceLocator(IUnityContainer container)
        {
            _container = container;
        }

        public T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }

        public object GetInstance(Type type)
        {
            return _container.Resolve(type);
        }
    }
}