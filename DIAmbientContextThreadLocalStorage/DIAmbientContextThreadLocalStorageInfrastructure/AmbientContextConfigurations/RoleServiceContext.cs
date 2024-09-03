using DIAmbientContextThreadLocalStorageDomain.Actions;
using DIAmbientContextThreadLocalStorageInfrastructure.Interfaces;
using System;
using System.Threading;

namespace DIAmbientContextThreadLocalStorageInfrastructure.AmbientContextConfigurations
{
    public class RoleServiceContext
    {
        private static readonly ThreadLocal<IRoleService> _current = new ThreadLocal<IRoleService>();

        public static IRoleService Current
        {
            get => _current.Value;
            set => _current.Value = value;
        }

        public static IDisposable BeginScope(IRoleService service)
        {
            var previousService = _current.Value;
            _current.Value = service;
            return new DisposableAction(() => _current.Value = previousService);
        }
    }
}
