using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
    public class StarService : IStarService
    {
        private readonly IStarRepository _starRepository;
        private readonly StarConverter _starConverter;

        public StarService(IStarRepository starRepository, StarConverter starConverter)
        {
            _starRepository = starRepository;
            _starConverter = starConverter;
        }

        public List<StarResponse> GetAllStarResponses(bool includeMedia)
        {
            IQueryable<Star> stars = _starRepository.GetAllStars(includeMedia);
            return _starConverter.Convert(stars.AsNoTracking().ToList());
        }

        public StarResponse? GetStarResponseById(int id, bool includeMedia)
        {
            Star? foundStar = _starRepository.GetStarById(id, includeMedia);
            if (foundStar != null)
            {
                return _starConverter.Convert(foundStar);
            }
            return null;
        }

        public void PostStar(StarRequest starRequest)
        {
            Star newStar = _starConverter.Convert(starRequest);
            _starRepository.AddStar(newStar);
        }

        public int UpdateStar(int id, StarRequest starRequest)
        {
            Star? star = _starRepository.GetStarById(id);
            if (star != null)
            {
                star.Name = starRequest.Name;
                _starRepository.UpdateStar(star);
                return 1;
            }
            return -1;
        }

        public int DeleteStar(int id)
        {
            Star? star = _starRepository.GetStarById(id);
            if (star != null)
            {
                _starRepository.DeleteStar(star);
                return 1;
            }
            return -1;
        }

    }
}

