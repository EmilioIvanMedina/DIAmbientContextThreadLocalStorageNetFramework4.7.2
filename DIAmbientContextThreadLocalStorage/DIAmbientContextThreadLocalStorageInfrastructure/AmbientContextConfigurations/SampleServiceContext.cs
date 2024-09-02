using DIAmbientContextThreadLocalStorageDomain.Actions;
using DIAmbientContextThreadLocalStorageInfrastructure.Interfaces;
using System;
using System.Threading;

namespace DIAmbientContextThreadLocalStorageInfrastructure.AmbientContextConfigurations
{
    public class SampleServiceContext
    {
        private static readonly ThreadLocal<ISampleService> _current = new ThreadLocal<ISampleService>();

        public static ThreadLocal<ISampleService> Current => _current;

        public static IDisposable BeginScope(ISampleService service)
        {
            var previousService = _current.Value;
            _current.Value = service;
            return new DisposableAction(() => _current.Value = previousService);
        }
    }
}
