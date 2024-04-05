﻿using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models.CrossTables;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
	public class UserFavoriteService : IUserFavoriteService
    {
        private readonly IUserFavoriteRepository _userFavoriteRepository;
        private readonly UserFavoriteConverter _userFavoriteConverter;

        public UserFavoriteService(IUserFavoriteRepository userFavoriteRepository, UserFavoriteConverter userFavoriteConverter)
        {
            _userFavoriteRepository = userFavoriteRepository;
            _userFavoriteConverter = userFavoriteConverter;
        }

        public List<UserFavoriteResponse> GetAllUserFavoriteResponses()
        {
            IQueryable<UserFavorite> userFavorites = _userFavoriteRepository.GetAllUserFavorites();
            return _userFavoriteConverter.Convert(userFavorites.ToList());
        }

        public List<UserFavoriteResponse> GetUserFavoriteResponsesByUserId(long userId)
        {
            IQueryable<UserFavorite> userFavorites = _userFavoriteRepository.GetUserFavoritesByUserId(userId);
            return _userFavoriteConverter.Convert(userFavorites.ToList());
        }

        public List<UserFavoriteResponse> GetUserFavoriteResponsesByMediaId(int mediaId)
        {
            IQueryable<UserFavorite> userFavorites = _userFavoriteRepository.GetUserFavoritesByMediaId(mediaId);
            return _userFavoriteConverter.Convert(userFavorites.ToList());
        }

        public void AddUserFavorite(UserFavoriteRequest userFavoriteRequest)
        {
            var userFavorite = _userFavoriteConverter.Convert(userFavoriteRequest);
            _userFavoriteRepository.AddUserFavorite(userFavorite);
        }

        public void RemoveUserFavorite(UserFavorite userFavorite)
        {
            _userFavoriteRepository.DeleteUserFavorite(userFavorite);
        }

    }
}

