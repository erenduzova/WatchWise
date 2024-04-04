using System;
using WatchWise.Models.CrossTables;

namespace WatchWise.Repositories.Interfaces
{
	public interface IUserFavoriteRepository
	{
        IQueryable<UserFavorite> GetAllUserFavorites();
        UserFavorite? GetUserFavoriteByUserId(long userId);
        UserFavorite? GetUserFavoriteByMediaId(int mediaId);
        void AddUserFavorite(UserFavorite userFavorite);
        void DeleteUserFavorite(UserFavorite userFavorite);
    }
}

