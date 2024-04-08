using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
	public interface IUserPlanService
	{
        List<UserPlanResponse> GetAllUserPlanResponses();
        UserPlanResponse? GetUserPlanResponsesById(long id);
        List<UserPlanResponse> GetUserPlanResponsesByUserId(long userId);
        List<UserPlanResponse> GetUserPlanResponsesByPlanId(short planId);
        void AddUserPlan(UserPlanRequest userPlanRequest);
        void AddUserPlan(long userId, short planId);
    }
}

