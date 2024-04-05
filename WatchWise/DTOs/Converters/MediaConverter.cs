using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

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
                GenreIds = new List<short>(),
                RestrictionIds = new List<byte>(),
                DirectorIds = new List<int>(),
                StarIds = new List<int>()
            };
            if (media.MediaGenres != null)
            {
                mediaResponse.GenreIds = media.MediaGenres.Select(ms => ms.GenreId).ToList();
            }
            if (media.MediaStars != null)
            {
                mediaResponse.StarIds = media.MediaStars.Select(ms => ms.StarId).ToList();
            }
            if (media.MediaDirectors != null)
            {
                mediaResponse.DirectorIds = media.MediaDirectors.Select(ms => ms.DirectorId).ToList();
            }
            if (media.MediaRestrictions != null)
            {
                mediaResponse.RestrictionIds = media.MediaRestrictions.Select(ms => ms.RestrictionId).ToList();
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

