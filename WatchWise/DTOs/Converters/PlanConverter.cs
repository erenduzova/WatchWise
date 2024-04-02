using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Converters
{
	public class PlanConverter
	{
        public Plan Convert(PlanRequest planRequest)
        {
            Plan newPlan = new()
            {
                Name = planRequest.Name,
                Price = planRequest.Price,
                MaxResolution = planRequest.MaxResolution,
                UserPlans = new List<UserPlan>()
            };
            return newPlan;
        }

        public PlanResponse Convert(Plan plan)
        {
            PlanResponse planResponse = new()
            {
                Id = plan.Id,
                Name = plan.Name,
                Price = plan.Price,
                MaxResolution = plan.MaxResolution,
                UserPlans = new List<UserPlan>()
            };
            if (plan.UserPlans != null)
            {
                planResponse.UserPlans = plan.UserPlans;
            }
            return planResponse;
        }

        public List<PlanResponse> Convert(List<Plan> plans)
        {
            List<PlanResponse> planResponse = new();
            foreach (Plan plan in plans)
            {
                planResponse.Add(Convert(plan));
            }
            return planResponse;
        }
    }
}

