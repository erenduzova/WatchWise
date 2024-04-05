using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
	public class MediaService : IMediaService
	{
        private readonly IMediaRepository _mediaRepository;
        private readonly MediaConverter _mediaConverter;

        public MediaService(IMediaRepository mediaRepository, MediaConverter mediaConverter)
        {
            _mediaRepository = mediaRepository;
            _mediaConverter = mediaConverter;
        }

        public List<MediaResponse> GetAllMediaResponses(bool includeMediaGenres
            , bool includeMediaStars
            , bool includeMediaDirectors
            , bool includeMediaRestrictions
            , bool includeUserFavorites)
        {
            IQueryable<Media> media = _mediaRepository.GetAllMedia(includeMediaGenres
            , includeMediaStars
            , includeMediaDirectors
            , includeMediaRestrictions
            , includeUserFavorites);

            return _mediaConverter.Convert(media.AsNoTracking().ToList());
        }

        public MediaResponse? GetMediaResponseById(int id
            , bool includeMediaGenres
            , bool includeMediaStars
            , bool includeMediaDirectors
            , bool includeMediaRestrictions
            , bool includeUserFavorites)
        {
            Media? foundMedia = _mediaRepository.GetMediaById(id);
            if (foundMedia != null)
            {
                return _mediaConverter.Convert(foundMedia);
            }
            return null;
        }

        public void PostMedia(MediaRequest mediaRequest)
        {
            Media newMedia = _mediaConverter.Convert(mediaRequest);
            _mediaRepository.AddMedia(newMedia);
        }

        public int UpdateMedia(int id, MediaRequest mediaRequest)
        {
            Media? media = _mediaRepository.GetMediaById(id);
            if (media != null)
            {
                if (mediaRequest.Name != null)
                {
                    media.Name = mediaRequest.Name;
                }

                if (mediaRequest.Description != null)
                {
                    media.Description = mediaRequest.Description;
                }
                media.ImdbRating = mediaRequest.ImdbRating;
                _mediaRepository.UpdateMedia(media);
                return 1;
            }
            return -1;
        }

        public int DeleteMedia(int id)
        {
            Media? media = _mediaRepository.GetMediaById(id);
            if (media != null)
            {
                media.Passive = true;
                _mediaRepository.UpdateMedia(media);
                return 1;
            }
            return -1;
        }

    }
}

