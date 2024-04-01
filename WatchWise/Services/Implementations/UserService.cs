using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;
        private readonly WatchWiseUserConverter _userConverter;
        private readonly SignInManager<WatchWiseUser> _signInManager;

        public UserService(IUserRepository usersRepository, WatchWiseUserConverter userConverter, SignInManager<WatchWiseUser> signInManager)
        {
            _usersRepository = usersRepository;
            _userConverter = userConverter;
            _signInManager = signInManager;
        }

        public List<WatchWiseUserResponse> GetAllUsersResponses(bool includePassive)
        {
            IQueryable<WatchWiseUser> users = _usersRepository.GetAllUsers(includePlans:true, includeWatchedEpisodes:true, includeFavorites: true);
            if (includePassive == false)
            {
                users = users.Where(u => u.Passive == false);
            }
            return _userConverter.Convert(users.AsNoTracking().ToList());
        }

        public WatchWiseUserResponse? GetWatchWiseUserResponseById(long id)
        {
            WatchWiseUser? foundWatchWiseUser = _usersRepository.GetUserById(id, includePlans: true, includeWatchedEpisodes: true, includeFavorites: true);
            if (foundWatchWiseUser != null)
            {
                return _userConverter.Convert(foundWatchWiseUser);
            }
            return null;
        }

        public IdentityResult PostUser(WatchWiseUserRequest watchWiseUserRequest)
        {
            WatchWiseUser newUser = _userConverter.Convert(watchWiseUserRequest);
            return _usersRepository.AddUser(newUser, watchWiseUserRequest.Password);
        }

        public int DeleteUser(long id)
        {
            WatchWiseUser? foundWatchWiseUser = _usersRepository.GetUserById(id);
            if (foundWatchWiseUser != null)
            {
                foundWatchWiseUser.Passive = true;
                _usersRepository.UpdateUser(foundWatchWiseUser);
                return 1;
            }
            return -1;
        }

        public int UpdateUser(long id, WatchWiseUserUpdateRequest watchWiseUserUpdateRequest)
        {
            WatchWiseUser? existingUser = _usersRepository.GetUserById(id);
            if (existingUser != null)
            {
                if (watchWiseUserUpdateRequest.PhoneNumber != null)
                {
                    existingUser.PhoneNumber = watchWiseUserUpdateRequest.PhoneNumber;
                }
                if (watchWiseUserUpdateRequest.UserName != null)
                {
                    existingUser.UserName = watchWiseUserUpdateRequest.UserName;
                }
                if (watchWiseUserUpdateRequest.Email != null)
                {
                    existingUser.Email = watchWiseUserUpdateRequest.Email;
                }
                _usersRepository.UpdateUser(existingUser);
                return 1;
            }
            return -1;
        }

        public SignInResult LogIn(LogInRequest logInRequest)
        {
            string userName = logInRequest.UserName;
            string password = logInRequest.Password;
            WatchWiseUser? watchWiseUser = _usersRepository.GetUserByUserName(userName, includePlans: true);

            if (watchWiseUser == null)
            {
                return SignInResult.NotAllowed;
            }

            if (watchWiseUser.UserPlans?.Where(u => u.EndDate >= DateTime.Today).Any() == false)
            {
                watchWiseUser.Passive = true;
                _usersRepository.UpdateUser(watchWiseUser);
            }

            return _signInManager.PasswordSignInAsync(watchWiseUser, password, false, false).Result;
        }
    }
}

