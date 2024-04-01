using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
	public interface IStarService
	{
        List<StarResponse> GetAllStarResponses();
        StarResponse? GetStarResponseById(int id);
        void PostStar(StarRequest starRequest);
        int DeleteStar(int id);
        int UpdateStar(int id, StarRequest starRequest);
    }
}

