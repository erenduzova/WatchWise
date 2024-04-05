using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models.CrossTables;

namespace WatchWise.Services.Interfaces
{
	public interface IMediaRestrictionService
	{
        List<MediaRestrictionResponse> GetAllMediaRestrictionResponses();
        List<MediaRestrictionResponse> GetMediaRestrictionResponsesByMediaId(int id);
        List<MediaRestrictionResponse> GetMediaRestrictionResponsesByRestrictionId(byte id);
        void PostMediaRestriction(MediaRestrictionRequest mediaRestrictionRequest);
        void DeleteMediaRestriction(MediaRestriction mediaRestriction);
    }
}

