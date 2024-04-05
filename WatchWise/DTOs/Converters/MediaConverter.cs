using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Converters
{
	public class MediaConverter
	{
        public Media Convert(MediaRequest mediaRequest)
        {
            Media newMedia = new()
            {
                Name = mediaRequest.Name,
                Description = mediaRequest.Description,
                ImdbRating = mediaRequest.ImdbRating,
                Passive = mediaRequest.Passive
            };
            return newMedia;
        }

        public MediaResponse Convert(Media media)
        {
            MediaResponse mediaResponse = new()
            {
                Id = media.Id,
                Name = media.Name,
                Description = media.Description,
                ImdbRating = media.ImdbRating,
                Passive = media.Passive,
                MediaGenres = new List<MediaGenre>(),
                MediaStars = new List<MediaStar>(),
                MediaDirectors = new List<MediaDirector>(),
                MediaRestrictions = new List<MediaRestriction>(),
                UserFavorites = new List<UserFavorite>()
            };
            if (media.MediaGenres != null)
            {
                mediaResponse.MediaGenres = media.MediaGenres;
            }
            if (media.MediaStars != null)
            {
                mediaResponse.MediaStars = media.MediaStars;
            }
            if (media.MediaDirectors != null)
            {
                mediaResponse.MediaDirectors = media.MediaDirectors;
            }
            if (media.MediaRestrictions != null)
            {
                mediaResponse.MediaRestrictions = media.MediaRestrictions;
            }
            if (media.UserFavorites != null)
            {
                mediaResponse.UserFavorites = media.UserFavorites;
            }
            return mediaResponse;
        }

        public List<MediaResponse> Convert(List<Media> mediaList)
        {
            List<MediaResponse> mediaResponses = new();
            foreach (Media media in mediaList)
            {
                mediaResponses.Add(Convert(media));
            }
            return mediaResponses;
        }
    }
}

