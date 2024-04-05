using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models.CrossTables;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
	public class UserPlanService : IUserPlanService
	{
        private readonly IUserPlanRepository _userPlanRepository;
        private readonly UserPlanConverter _userPlanConverter;

        public UserPlanService(IUserPlanRepository userPlanRepository, UserPlanConverter userPlanConverter)
        {
            _userPlanRepository = userPlanRepository;
            _userPlanConverter = userPlanConverter;
        }

        public List<UserPlanResponse> GetAllUserPlanResponses()
        {
            IQueryable<UserPlan> userPlans = _userPlanRepository.GetAllUserPlans();
            return _userPlanConverter.Convert(userPlans.ToList());
        }

        public UserPlanResponse? GetUserPlanResponsesById(long id)
        {
            UserPlan? foundUserPlan = _userPlanRepository.GetUserPlanById(id);
            if (foundUserPlan != null)
            {
                return _userPlanConverter.Convert(foundUserPlan);
            }
            return null;
        }

        public List<UserPlanResponse> GetUserPlanResponsesByUserId(long userId)
        {
            IQueryable<UserPlan> userPlans = _userPlanRepository.GetUserPlansByUserId(userId);
            return _userPlanConverter.Convert(userPlans.ToList());
        }

        public List<UserPlanResponse> GetUserPlanResponsesByPlanId(short planId)
        {
            IQueryable<UserPlan> userPlans = _userPlanRepository.GetUserPlansByPlanId(planId);
            return _userPlanConverter.Convert(userPlans.ToList());
        }

        public void AddUserPlan(UserPlanRequest userPlanRequest)
        {
            var userPlan = _userPlanConverter.Convert(userPlanRequest);
            _userPlanRepository.AddUserPlan(userPlan);
        }

    }
}

