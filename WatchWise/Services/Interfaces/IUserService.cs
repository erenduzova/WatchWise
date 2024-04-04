using Microsoft.AspNetCore.Identity;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
    public interface IUserService
    {
        List<WatchWiseUserResponse> GetAllUsersResponses(bool includePassive, bool includePlans, bool includeWatchedEpisodes, bool includeFavorites);
        WatchWiseUserResponse? GetWatchWiseUserResponseById(long id, bool includePlans, bool includeWatchedEpisodes, bool includeFavorites);
        IdentityResult PostUser(WatchWiseUserRequest watchWiseUserRequest);
        int DeleteUser(long id);
        int UpdateUser(long id, WatchWiseUserUpdateRequest watchWiseUserUpdateRequest);
        SignInResult LogIn(LogInRequest logInRequest);
    }
}

