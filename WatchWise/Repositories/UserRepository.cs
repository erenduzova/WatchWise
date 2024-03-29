using System;
using Microsoft.AspNetCore.Identity;
using WatchWise.Models;
using WatchWise.Services;

namespace WatchWise.Repositories
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

        public WatchWiseUser? GetUserById(long id)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.Id == id);
        }

        public IdentityResult AddUser(WatchWiseUser watchWiseUser, string password)
        {
            return _signInManager.UserManager.CreateAsync(watchWiseUser, password).Result;
        } 

        public void UpdateUser(WatchWiseUser watchWiseUser)
        {
            _signInManager.UserManager.UpdateAsync(watchWiseUser).Wait();
        }

        public WatchWiseUser? GetUserByUserName(string userName)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.UserName == userName);
        }
    }
}

