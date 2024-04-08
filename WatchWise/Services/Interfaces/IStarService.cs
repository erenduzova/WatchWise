using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
    public interface IStarService
    {
        List<StarResponse> GetAllStarResponses(bool includeMedia);
        StarResponse? GetStarResponseById(int id, bool includeMedia);
        void PostStar(StarRequest starRequest);
        int DeleteStar(int id);
        int UpdateStar(int id, StarRequest starRequest);
    }
}

