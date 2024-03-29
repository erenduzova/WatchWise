using System;
using Microsoft.AspNetCore.Identity;
using WatchWise.Models;

namespace WatchWise.Repositories
{
	public interface IUserRepository
	{
        IQueryable<WatchWiseUser> GetAllUsers();
        WatchWiseUser? GetUserById(long id);
        IdentityResult AddUser(WatchWiseUser watchWiseUser, string password);
        void UpdateUser(WatchWiseUser watchWiseUser);
        WatchWiseUser? GetUserByUserName(string userName);
    }
}

