using Microsoft.AspNetCore.Identity;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<WatchWiseRole> _roleManager;
        private readonly UserManager<WatchWiseUser> _userManager;

        public RoleRepository(RoleManager<WatchWiseRole> roleManager, UserManager<WatchWiseUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IQueryable<WatchWiseRole> GetAllRoles()
        {
            return _roleManager.Roles;
        }

        public IList<string> GetUserRoles(WatchWiseUser user)
        {
            return _userManager.GetRolesAsync(user).Result;
        }

        public IdentityResult AddToRole(WatchWiseUser user, string roleName)
        {
            return _userManager.AddToRoleAsync(user, roleName).Result;
        }

        public IdentityResult RemoveFromRole(WatchWiseUser user, string roleName)
        {
            return _userManager.RemoveFromRoleAsync(user, roleName).Result;
        }

    }
}
