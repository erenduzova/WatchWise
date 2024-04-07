using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
	public class PlanService : IPlanService
	{
        private readonly IPlanRepository _planRepository;
        private readonly PlanConverter _planConverter;

        public PlanService(IPlanRepository planRepository, PlanConverter planConverter)
        {
            _planRepository = planRepository;
            _planConverter = planConverter;
        }

        public List<PlanResponse> GetAllPlanResponses()
        {
            IQueryable<Plan> plans = _planRepository.GetAllPlans();
            return _planConverter.Convert(plans.AsNoTracking().ToList());
        }

        public PlanResponse? GetPlanResponseById(short id)
        {
            Plan? foundPlan = _planRepository.GetPlanById(id);
            if (foundPlan != null)
            {
                return _planConverter.Convert(foundPlan);
            }
            return null;
        }

        public void PostPlan(PlanRequest planRequest)
        {
            Plan newPlan = _planConverter.Convert(planRequest);
            _planRepository.AddPlan(newPlan);
        }

        public int UpdatePlan(short id, PlanRequest planRequest)
        {
            Plan? plan = _planRepository.GetPlanById(id);
            if (plan != null)
            {
                plan.Name = planRequest.Name;
                plan.Price = planRequest.Price;
                plan.MaxResolution = planRequest.MaxResolution;
                _planRepository.UpdatePlan(plan);
                return 1;
            }
            return -1;
        }

    }
}

