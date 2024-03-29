using System;
using Microsoft.AspNetCore.Identity;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.Services
{
	public interface IUserService
	{
        List<WatchWiseUserResponse> GetAllUsersResponses(bool passiveUser);
        WatchWiseUserResponse? GetWatchWiseUserResponse(long id);
        IdentityResult PostUser(WatchWiseUserRequest watchWiseUserRequest);
        int DeleteUser(long id);
        int UpdateUser(long id, WatchWiseUserUpdateRequest watchWiseUserUpdateRequest);
        SignInResult LogIn(LogInRequest logInRequest);
    }
}

