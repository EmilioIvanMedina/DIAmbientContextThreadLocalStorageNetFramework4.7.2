using DIAmbientContextThreadLocalStorageInfrastructure.Interfaces;
using DIAmbientContextThreadLocalStorageInfrastructure.Structs;

namespace DIAmbientContextThreadLocalStorageInfrastructure.Implementations
{
    public class RoleService : IRoleService
    {
        public string GetUserRole()
        {
            return Role.Viewer;
        }

        public bool UserHasRole(string role)
        {
            return Role.IsAdmin(role);
        }
    }
}
