using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<WatchWiseRole> GetAllRoles()
        {
            IQueryable<WatchWiseRole> roles = _roleRepository.GetAllRoles();
            return roles.AsNoTracking().ToList();
        }

        public List<string> GetRolesByUserId(WatchWiseUser user)
        {
            IList<string> roles = _roleRepository.GetUserRoles(user);
            return roles.ToList();
        }

        public int AddRole(WatchWiseUser user, string roleName)
        {
            IList<string> foundRoles = _roleRepository.GetUserRoles(user);
            if (!foundRoles.Contains(roleName))
            {
                IdentityResult addResult = _roleRepository.AddToRole(user, roleName);
                if (addResult.Succeeded)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }

        public int RemoveRole(WatchWiseUser user, string roleName)
        {
            IList<string> foundRoles = _roleRepository.GetUserRoles(user);
            if (foundRoles.Contains(roleName))
            {
                IdentityResult removeResult = _roleRepository.RemoveFromRole(user, roleName);
                if (removeResult.Succeeded)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }

        public void RemoveAllRolesFromUser(WatchWiseUser user)
        {
            IList<string> foundRoles = _roleRepository.GetUserRoles(user);
            foundRoles.Remove("Admin");
            if (foundRoles.Count > 0)
            {
                foreach (string roleName in foundRoles)
                {
                    _roleRepository.RemoveFromRole(user, roleName);
                }
            }
        }

        public bool IsInRole(WatchWiseUser user, string roleName)
        {
            IList<string> foundRoles = _roleRepository.GetUserRoles(user);
            return foundRoles.Contains(roleName);
        }

    }
}
