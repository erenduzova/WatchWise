using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
	public interface IRestrictionService
	{
        List<RestrictionResponse> GetAllRestrictionResponses();
        RestrictionResponse? GetRestrictionResponseById(byte id);
        int PostRestriction(RestrictionRequest restrictionRequest);
        int UpdateRestriction(byte id, RestrictionRequest restrictionRequest);
    }
}

