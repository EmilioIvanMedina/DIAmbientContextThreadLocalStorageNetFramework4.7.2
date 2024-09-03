using DIAmbientContextThreadLocalStorageDomain.Actions;
using DIAmbientContextThreadLocalStorageInfrastructure.Interfaces;
using System;
using System.Threading;

namespace DIAmbientContextThreadLocalStorageInfrastructure.AmbientContextConfigurations
{
    public class RoleServiceContext
    {
        private static readonly ThreadLocal<IRoleService> _current = new ThreadLocal<IRoleService>();

        public static ThreadLocal<IRoleService> Current => _current;

        public static IDisposable BeginScope(IRoleService service)
        {
            var previousService = _current.Value;
            _current.Value = service;
            return new DisposableAction(() => _current.Value = previousService);
        }
    }
}
