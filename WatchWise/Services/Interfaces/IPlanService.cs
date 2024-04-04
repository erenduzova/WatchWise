using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
	public interface IPlanService
	{
        List<PlanResponse> GetAllPlanResponses(bool includeUsers);
        PlanResponse? GetPlanResponseById(short id, bool includeUsers);
        void PostPlan(PlanRequest planRequest);
        int UpdatePlan(short id, PlanRequest planRequest);
    }
}

