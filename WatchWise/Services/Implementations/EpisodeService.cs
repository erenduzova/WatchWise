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
        private readonly EpisodeConverter _episodeConverter;

        public EpisodeService(IEpisodeRepository episodeRepository, EpisodeConverter episodeConverter)
        {
            _episodeRepository = episodeRepository;
            _episodeConverter = episodeConverter;
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

    }
}

