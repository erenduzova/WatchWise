using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
    public interface IMediaRestrictionService
    {
        List<MediaRestrictionResponse> GetAllMediaRestrictionResponses();
        List<MediaRestrictionResponse> GetMediaRestrictionResponsesByMediaId(int id);
        List<MediaRestrictionResponse> GetMediaRestrictionResponsesByRestrictionId(byte id);
        int PostMediaRestriction(MediaRestrictionRequest mediaRestrictionRequest);
        int DeleteMediaRestriction(MediaRestrictionRequest mediaRestrictionRequest);
    }
}

