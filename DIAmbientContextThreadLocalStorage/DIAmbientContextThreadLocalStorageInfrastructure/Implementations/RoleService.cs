using DIAmbientContextThreadLocalStorageInfrastructure.Interfaces;
using DIAmbientContextThreadLocalStorageInfrastructure.Structs;
using System.Threading.Tasks;

namespace DIAmbientContextThreadLocalStorageInfrastructure.Implementations
{
    public class RoleService : IRoleService
    {
        private string _currentRole;

        public async Task<string> GetUserRole()
        {
            _currentRole = Role.Viewer;
            return _currentRole;
        }

        public async Task SetUserRole(string roleName)
        {
            _currentRole = roleName;
        }

        public async Task<bool> UserHasRole(string role)
        {
            Task.Delay(10000).Wait();
            return Role.IsValidRole(_currentRole) && Role.IsValidRole(role) && _currentRole == role;
        }
    }
}
