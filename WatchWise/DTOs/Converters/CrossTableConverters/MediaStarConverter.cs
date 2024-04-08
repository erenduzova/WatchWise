using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.DTOs.Converters
{
    public class MediaStarConverter
    {
        public MediaStar Convert(MediaStarRequest mediaStarRequest)
        {
            MediaStar newMediaStar = new()
            {
                MediaId = mediaStarRequest.MediaId,
                StarId = mediaStarRequest.StarId
            };
            return newMediaStar;
        }

        public MediaStarResponse Convert(MediaStar mediaStar)
        {
            MediaStarResponse mediaStarResponse = new()
            {
                MediaId = mediaStar.MediaId,
                StarId = mediaStar.StarId
            };
            return mediaStarResponse;
        }

        public List<MediaStarResponse> Convert(List<MediaStar> mediaStars)
        {
            List<MediaStarResponse> mediaStarResponses = new();
            foreach (MediaStar mediaStar in mediaStars)
            {
                mediaStarResponses.Add(Convert(mediaStar));
            }
            return mediaStarResponses;
        }

    }
}

