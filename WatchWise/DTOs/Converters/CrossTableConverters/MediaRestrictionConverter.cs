using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Converters
{
    public class MediaRestrictionConverter
    {
        public MediaRestriction Convert(MediaRestrictionRequest mediaRestrictionRequest)
        {
            MediaRestriction newMediaRestriction = new()
            {
                MediaId = mediaRestrictionRequest.MediaId,
                RestrictionId = mediaRestrictionRequest.RestrictionId
            };
            return newMediaRestriction;
        }

        public MediaRestrictionResponse Convert(MediaRestriction mediaRestriction)
        {
            MediaRestrictionResponse mediaRestrictionResponse = new()
            {
                MediaId = mediaRestriction.MediaId,
                RestrictionId = mediaRestriction.RestrictionId
            };
            return mediaRestrictionResponse;
        }

        public List<MediaRestrictionResponse> Convert(List<MediaRestriction> mediaRestrictions)
        {
            List<MediaRestrictionResponse> mediaRestrictionResponses = new();
            foreach (MediaRestriction mediaRestriction in mediaRestrictions)
            {
                mediaRestrictionResponses.Add(Convert(mediaRestriction));
            }
            return mediaRestrictionResponses;
        }

    }
}

