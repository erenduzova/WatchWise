using System;
using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Repositories.Implementations;
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

        public List<MediaResponse> GetAllMediaResponses()
        {
            IQueryable<Media> media = _mediaRepository.GetAllMedia(includeMediaGenres: false
            , includeMediaStars: false
            , includeMediaDirectors: false
            , includeMediaRestrictions: false
            , includeUserFavorites: false);

            return _mediaConverter.Convert(media.AsNoTracking().ToList());
        }

        public MediaResponse? GetMediaResponseById(int id)
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

