using WatchWise.Models;

namespace WatchWise.Services.Interfaces
{
    public interface IRoleService
    {
        List<WatchWiseRole> GetAllRoles();
        List<string> GetRolesByUserId(WatchWiseUser user);
        int AddRole(WatchWiseUser user, string roleName);
        int RemoveRole(WatchWiseUser user, string roleName);
        void RemoveAllRolesFromUser(WatchWiseUser user);
        bool IsInRole(WatchWiseUser user, string roleName);
    }
}
