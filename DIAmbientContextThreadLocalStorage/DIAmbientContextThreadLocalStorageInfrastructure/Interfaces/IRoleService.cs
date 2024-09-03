namespace DIAmbientContextThreadLocalStorageInfrastructure.Interfaces
{
    public interface IRoleService
    {
        string GetUserRole();
        bool UserHasRole(string role);
    }
}
