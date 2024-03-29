using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Repositories;

namespace WatchWise.Services
{
	public class UserService : IUserService
	{
        private readonly IUserRepository _usersRepository;
        private readonly WatchWiseUserConverter _userConverter;

        public UserService(IUserRepository usersRepository, WatchWiseUserConverter userConverter)
        {
            _usersRepository = usersRepository;
            _userConverter = userConverter;
        }

        public List<WatchWiseUserResponse> GetAllUsersResponses(bool passiveUser)
        {
            IQueryable<WatchWiseUser> users = _usersRepository.GetAllUsers();
            if (passiveUser == false)
            {
                users = users.Where(u => u.Passive == false);
            }
            return _userConverter.Convert(users.AsNoTracking().ToList());
        }

        public WatchWiseUserResponse? GetWatchWiseUserResponse(long id)
        {
            WatchWiseUser? foundWatchWiseUser = _usersRepository.GetUserById(id);
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
                _usersRepository.UpdateUser(existingUser);
                return 1;
            }
            return -1;
        }
    }
}

