using System;
using Microsoft.AspNetCore.Identity;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<WatchWiseUser> GetAllUsers();
        IdentityResult AddUser(WatchWiseUser watchWiseUser, string password);
        void UpdateUser(WatchWiseUser watchWiseUser);
        WatchWiseUser? GetUserById(long id, bool includePlans = false, bool includeWatchedEpisodes = false, bool includeFavorites = false);
        WatchWiseUser? GetUserByUserName(string userName, bool includePlans = false, bool includeWatchedEpisodes = false, bool includeFavorites = false);
    }
}

