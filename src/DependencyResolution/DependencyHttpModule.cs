using System;
using System.Web;

namespace DependencyResolution
{
    public class DependencyHttpModule : IHttpModule
    {
        private static bool _dependenciesRegistered;
        private static readonly object Lock = new object();

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, eventArgs) => EnsureDependenciesRegistered();
        }

        private static void EnsureDependenciesRegistered()
        {
            if (_dependenciesRegistered) return;

            lock (Lock)
            {
                DependencyRegistrar.RegisterAllDependencies();
                _dependenciesRegistered = true;
            }
        }

        public void Dispose() { }
    }
}