using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models.CrossTables;

namespace WatchWise.Services.Interfaces
{
	public interface IUserFavoriteService
	{
        List<UserFavoriteResponse> GetAllUserFavoriteResponses();
        List<UserFavoriteResponse> GetUserFavoriteResponsesByUserId(long userId);
        List<UserFavoriteResponse> GetUserFavoriteResponsesByMediaId(int mediaId);
        void AddUserFavorite(UserFavoriteRequest userFavoriteRequest);
        void RemoveUserFavorite(UserFavorite userFavorite);
    }
}

