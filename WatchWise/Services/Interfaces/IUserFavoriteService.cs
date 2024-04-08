using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
	public interface IUserFavoriteService
	{
        List<UserFavoriteResponse> GetAllUserFavoriteResponses();
        List<UserFavoriteResponse> GetUserFavoriteResponsesByUserId(long userId);
        List<UserFavoriteResponse> GetUserFavoriteResponsesByMediaId(int mediaId);
        int AddUserFavorite(UserFavoriteRequest userFavoriteRequest);
        int DeleteUserFavorite(UserFavoriteRequest userFavoriteRequest);
    }
}

