using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
	public interface IRestrictionService
	{
        List<RestrictionResponse> GetAllRestrictionResponses(bool includeMedia);
        RestrictionResponse? GetRestrictionResponseById(byte id , bool includeMedia);
        int PostRestriction(RestrictionRequest restrictionRequest);
        int UpdateRestriction(byte id, RestrictionRequest restrictionRequest);
    }
}

