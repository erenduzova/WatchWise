using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
    public interface IPlanService
    {
        List<PlanResponse> GetAllPlanResponses();
        PlanResponse? GetPlanResponseById(short id);
        int PostPlan(PlanRequest planRequest);
        int UpdatePlan(short id, PlanRequest planRequest);
    }
}

