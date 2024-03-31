using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services;

namespace WatchWise.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<WatchWiseUser> _signInManager;

        public UserRepository(SignInManager<WatchWiseUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IQueryable<WatchWiseUser> GetAllUsers()
        {
            return _signInManager.UserManager.Users;
        }

        public IdentityResult AddUser(WatchWiseUser watchWiseUser, string password)
        {
            return _signInManager.UserManager.CreateAsync(watchWiseUser, password).Result;
        }

        public void UpdateUser(WatchWiseUser watchWiseUser)
        {
            _signInManager.UserManager.UpdateAsync(watchWiseUser).Wait();
        }
        public WatchWiseUser? GetUserById(long id, bool includePlans = false, bool includeWatchedEpisodes = false, bool includeFavorites = false)
        {
            IQueryable<WatchWiseUser> users = _signInManager.UserManager.Users;

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
            return users.FirstOrDefault(u => u.Id == id);
        }

        public WatchWiseUser? GetUserByUserName(string userName, bool includePlans = false, bool includeWatchedEpisodes = false, bool includeFavorites = false)
        {
            IQueryable<WatchWiseUser> users = _signInManager.UserManager.Users;

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

            return users.FirstOrDefault(u => u.UserName == userName);
        }
    }
}

