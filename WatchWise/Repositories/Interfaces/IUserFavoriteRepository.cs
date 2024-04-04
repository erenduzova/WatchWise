using System;
using WatchWise.Models.CrossTables;

namespace WatchWise.Repositories.Interfaces
{
	public interface IUserFavoriteRepository
	{
        IQueryable<UserFavorite> GetAllUserFavorites();
        IQueryable<UserFavorite> GetUserFavoritesByUserId(long userId);
        IQueryable<UserFavorite> GetUserFavoritesByMediaId(int mediaId);
        void AddUserFavorite(UserFavorite userFavorite);
        void DeleteUserFavorite(UserFavorite userFavorite);
    }
}

