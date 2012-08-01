using System;
using System.Collections.Generic;

namespace Core
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
        object GetInstance(Type type);
        IEnumerable<object> GetAll(Type serviceType);
        IEnumerable<T> GetAll<T>();
    }

    public static class ServiceLocator
    {
        private static IServiceLocator _current;
        public static IServiceLocator Current
        {
            get
            {
                return _current;
            }
        }

        public static void SetServiceLocator(Func<IServiceLocator> create)
        {
            if (create == null) throw new ArgumentNullException("create");
            _current = create();
        }
    }
}