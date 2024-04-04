using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Converters
{
	public class UserPlanConverter
	{
        public UserPlan Convert(UserPlanRequest userPlanRequest)
        {
            UserPlan newUserPlan = new()
            {
                UserId = userPlanRequest.UserId,
                PlanId = userPlanRequest.PlanId,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths(1)
            };
            return newUserPlan;
        }

        public UserPlanResponse Convert(UserPlan userPlan)
        {
            UserPlanResponse userPlanResponse = new()
            {
                Id = userPlan.Id,
                UserId = userPlan.UserId,
                PlanId = userPlan.PlanId,
                StartDate = userPlan.StartDate,
                EndDate = userPlan.EndDate
            };
            return userPlanResponse;
        }

        public List<UserPlanResponse> Convert(List<UserPlan> userPlans)
        {
            List<UserPlanResponse> userPlanResponses = new();
            foreach (UserPlan userPlan in userPlans)
            {
                userPlanResponses.Add(Convert(userPlan));
            }
            return userPlanResponses;
        }

    }
}

