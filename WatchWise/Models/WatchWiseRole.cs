using Microsoft.AspNetCore.Identity;

namespace WatchWise.Models
{
    public class WatchWiseRole : IdentityRole<long>
    {
        public WatchWiseRole(string roleName) : base(roleName)
        {

        }
        public WatchWiseRole()
        {

        }
    }
}

