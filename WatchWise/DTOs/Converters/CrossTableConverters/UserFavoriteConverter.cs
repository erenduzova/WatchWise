using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Converters
{
    public class UserFavoriteConverter
    {
        public UserFavorite Convert(UserFavoriteRequest userFavoriteRequest)
        {
            UserFavorite newUserFavorite = new()
            {
                UserId = userFavoriteRequest.UserId,
                MediaId = userFavoriteRequest.MediaId
            };
            return newUserFavorite;
        }

        public UserFavoriteResponse Convert(UserFavorite userFavorite)
        {
            UserFavoriteResponse userFavoriteResponse = new()
            {
                UserId = userFavorite.UserId,
                MediaId = userFavorite.MediaId
            };
            return userFavoriteResponse;
        }

        public List<UserFavoriteResponse> Convert(List<UserFavorite> userFavorites)
        {
            List<UserFavoriteResponse> userFavoriteResponses = new();
            foreach (UserFavorite userFavorite in userFavorites)
            {
                userFavoriteResponses.Add(Convert(userFavorite));
            }
            return userFavoriteResponses;
        }


    }
}

