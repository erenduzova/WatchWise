using Microsoft.AspNetCore.Identity;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<WatchWiseRole> GetAllRoles();
        IList<string> GetUserRoles(WatchWiseUser user);
        IdentityResult AddToRole(WatchWiseUser user, string roleName);
        IdentityResult RemoveFromRole(WatchWiseUser user, string roleName);
    }
}
