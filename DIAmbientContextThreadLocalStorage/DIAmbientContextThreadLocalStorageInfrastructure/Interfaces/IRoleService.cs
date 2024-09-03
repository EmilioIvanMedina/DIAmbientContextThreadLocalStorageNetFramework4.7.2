using System.Threading.Tasks;

namespace DIAmbientContextThreadLocalStorageInfrastructure.Interfaces
{
    public interface IRoleService
    {
        Task<string> GetUserRole();

        Task SetUserRole(string roleName);

        Task<bool> UserHasRole(string role);
    }
}
