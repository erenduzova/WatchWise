using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models.CrossTables;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
	public class UserWatchedEpisodeService : IUserWatchedEpisodeService
	{
        private readonly IUserWatchedEpisodeRepository _userWatchedEpisodeRepository;
        private readonly UserWatchedEpisodeConverter _userWatchedEpisodeConverter;

        public UserWatchedEpisodeService(IUserWatchedEpisodeRepository userWatchedEpisodeRepository, UserWatchedEpisodeConverter userWatchedEpisodeConverter)
        {
            _userWatchedEpisodeRepository = userWatchedEpisodeRepository;
            _userWatchedEpisodeConverter = userWatchedEpisodeConverter;
        }

        public List<UserWatchedEpisodeResponse> GetAllUserWatchedEpisodeResponses()
        {
            IQueryable<UserWatchedEpisode> userWatchedEpisodes = _userWatchedEpisodeRepository.GetAllUserWatchedEpisodes();
            return _userWatchedEpisodeConverter.Convert(userWatchedEpisodes.ToList());
        }

        public List<UserWatchedEpisodeResponse> GetUserWatchedEpisodeResponsesByUserId(long userId)
        {
            IQueryable<UserWatchedEpisode> userWatchedEpisodes = _userWatchedEpisodeRepository.GetUserWatchedEpisodesByUserId(userId);
            return _userWatchedEpisodeConverter.Convert(userWatchedEpisodes.ToList());
        }

        public List<UserWatchedEpisodeResponse> GetUserWatchedEpisodeResponsesByEpisodeId(long episodeId)
        {
            IQueryable<UserWatchedEpisode> userWatchedEpisodes = _userWatchedEpisodeRepository.GetUserWatchedEpisodesByEpisodeId(episodeId);
            return _userWatchedEpisodeConverter.Convert(userWatchedEpisodes.ToList());
        }

        public void AddUserWatchedEpisode(UserWatchedEpisodeRequest userWatchedEpisodeRequest)
        {
            var userWatchedEpisode = _userWatchedEpisodeConverter.Convert(userWatchedEpisodeRequest);
            _userWatchedEpisodeRepository.AddUserWatchedEpisode(userWatchedEpisode);
        }

        public void RemoveUserWatchedEpisode(UserWatchedEpisode userWatchedEpisode)
        {
            _userWatchedEpisodeRepository.DeleteUserWatchedEpisode(userWatchedEpisode);
        }

    }
}

