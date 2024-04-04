using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<WatchWiseUser> _signInManager;

        public UserRepository(SignInManager<WatchWiseUser> signInManager)
        {
            _signInManager = signInManager;
        }

        private IQueryable<WatchWiseUser> IncludeRealtedObjects(IQueryable<WatchWiseUser> users, bool includePlans, bool includeWatchedEpisodes, bool includeFavorites)
        {
            if (includePlans)
            {
                users = users.Include(u => u.UserPlans);
            }

            if (includeWatchedEpisodes)
            {
                users = users.Include(u => u.UserWatchedEpisodes);
            }

            if (includeFavorites)
            {
                users = users.Include(u => u.UserFavorites);
            }
            return users;
        }

        public IQueryable<WatchWiseUser> GetAllUsers(bool includePlans = false, bool includeWatchedEpisodes = false, bool includeFavorites = false)
        {
            IQueryable<WatchWiseUser> users = _signInManager.UserManager.Users;
            users = IncludeRealtedObjects(users, includePlans, includeWatchedEpisodes, includeFavorites);
            return users;
        }

        public WatchWiseUser? GetUserById(long id, bool includePlans = false, bool includeWatchedEpisodes = false, bool includeFavorites = false)
        {
            IQueryable<WatchWiseUser> users = _signInManager.UserManager.Users;
            users = IncludeRealtedObjects(users, includePlans, includeWatchedEpisodes, includeFavorites);
            return users.FirstOrDefault(u => u.Id == id);
        }

        public WatchWiseUser? GetUserByUserName(string userName, bool includePlans = false, bool includeWatchedEpisodes = false, bool includeFavorites = false)
        {
            IQueryable<WatchWiseUser> users = _signInManager.UserManager.Users;
            users = IncludeRealtedObjects(users, includePlans, includeWatchedEpisodes, includeFavorites);
            return users.FirstOrDefault(u => u.UserName == userName);
        }

        public IdentityResult AddUser(WatchWiseUser watchWiseUser, string password)
        {
            return _signInManager.UserManager.CreateAsync(watchWiseUser, password).Result;
        }

        public void UpdateUser(WatchWiseUser watchWiseUser)
        {
            _signInManager.UserManager.UpdateAsync(watchWiseUser).Wait();
        }

    }
}

