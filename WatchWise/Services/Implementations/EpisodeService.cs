using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserWatchedEpisodeService _userWatchedEpisodeService;
        private readonly EpisodeConverter _episodeConverter;

        public EpisodeService(IEpisodeRepository episodeRepository, IUserRepository userRepository, EpisodeConverter episodeConverter, IUserWatchedEpisodeService userWatchedEpisodeService)
        {
            _episodeRepository = episodeRepository;
            _userRepository = userRepository;
            _episodeConverter = episodeConverter;
            _userWatchedEpisodeService = userWatchedEpisodeService;
        }

        public List<EpisodeResponse> GetAllEpisodeResponses()
        {
            IQueryable<Episode> episodes = _episodeRepository.GetAllEpisodes();
            return _episodeConverter.Convert(episodes.AsNoTracking().ToList());
        }

        public EpisodeResponse? GetEpisodeResponseById(long id)
        {
            Episode? foundEpisode = _episodeRepository.GetEpisodeById(id);
            if (foundEpisode != null)
            {
                return _episodeConverter.Convert(foundEpisode);
            }
            return null;
        }

        public void PostEpisode(EpisodeRequest episodeRequest)
        {
            Episode newEpisode = _episodeConverter.Convert(episodeRequest);
            _episodeRepository.AddEpisode(newEpisode);
        }

        public int UpdateEpisode(long id, EpisodeUpdateRequest episodeUpdateRequest)
        {
            Episode? foundEpisode = _episodeRepository.GetEpisodeById(id);
            if (foundEpisode != null)
            {
                if (episodeUpdateRequest.Title != null)
                {
                    foundEpisode.Title = episodeUpdateRequest.Title;
                }
                if (episodeUpdateRequest.Description != null)
                {
                    foundEpisode.Description = episodeUpdateRequest.Description;
                }
                _episodeRepository.UpdateEpisode(foundEpisode);
                return 1;
            }
            return -1;
        }

        public int DeleteEpisode(long id)
        {
            Episode? foundEpisode = _episodeRepository.GetEpisodeById(id);
            if (foundEpisode != null)
            {
                foundEpisode.Passive = true;
                _episodeRepository.UpdateEpisode(foundEpisode);
                return 1;
            }
            return -1;
        }

        public int Watch(long id, long userId)
        {
            Episode? foundEpisode = _episodeRepository.GetEpisodeById(id);
            WatchWiseUser foundUser = _userRepository.GetUserById(userId,includeWatchedEpisodes:true)!;
            if (foundEpisode != null && foundEpisode.Passive == false)
            {
                foundEpisode.ViewCount++;
                _episodeRepository.UpdateEpisode(foundEpisode);
                if (!foundUser.UserWatchedEpisodes!.Any(uwe => uwe.EpisodeId == id))
                {
                    _userWatchedEpisodeService.AddUserWatchedEpisode(id, userId);
                }
                return 1;
            }
            return -1;
        }

    }
}

