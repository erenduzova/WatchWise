using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
    public class MediaStarService : IMediaStarService
    {
        private readonly IMediaStarRepository _mediaStarRepository;
        private readonly MediaStarConverter _mediaStarConverter;

        public MediaStarService(IMediaStarRepository mediaStarRepository, MediaStarConverter mediaStarConverter)
        {
            _mediaStarRepository = mediaStarRepository;
            _mediaStarConverter = mediaStarConverter;
        }

        public List<MediaStarResponse> GetAllMediaStarResponses()
        {
            IQueryable<MediaStar> mediaStars = _mediaStarRepository.GetAllMediaStars();
            return _mediaStarConverter.Convert(mediaStars.AsNoTracking().ToList());
        }

        public List<MediaStarResponse> GetMediaStarResponsesByMediaId(int id)
        {
            IQueryable<MediaStar> mediaStars = _mediaStarRepository.GetMediaStarsByMediaId(id);
            return _mediaStarConverter.Convert(mediaStars.AsNoTracking().ToList());
        }

        public List<MediaStarResponse> GetMediaStarResponsesByStarId(int id)
        {
            IQueryable<MediaStar> mediaStars = _mediaStarRepository.GetMediaStarsByStarId(id);
            return _mediaStarConverter.Convert(mediaStars.AsNoTracking().ToList());
        }

        public void PostMediaStar(MediaStarRequest mediaStarRequest)
        {
            MediaStar newMediaStar = _mediaStarConverter.Convert(mediaStarRequest);
            _mediaStarRepository.AddMediaStar(newMediaStar);
        }

        public void DeleteMediaStar(MediaStar mediaStar)
        {
            _mediaStarRepository.DeleteMediaStar(mediaStar);
        }

    }
}


