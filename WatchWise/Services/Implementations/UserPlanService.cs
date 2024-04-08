using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Models.CrossTables;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
    public class UserPlanService : IUserPlanService
    {
        private readonly IUserPlanRepository _userPlanRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserPlanConverter _userPlanConverter;

        public UserPlanService(IUserPlanRepository userPlanRepository, IUserRepository userRepository, UserPlanConverter userPlanConverter)
        {
            _userPlanRepository = userPlanRepository;
            _userRepository = userRepository;
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
            UserPlan userPlan = _userPlanConverter.Convert(userPlanRequest);
            _userPlanRepository.AddUserPlan(userPlan);
        }

        public void AddUserPlan(long userId, short planId)
        {
            WatchWiseUser foundUser = _userRepository.GetUserById(userId, includePlans: true)!;
            UserPlanRequest userPlanRequest = new()
            {
                UserId = userId,
                PlanId = planId,
            };
            UserPlan userPlan = _userPlanConverter.Convert(userPlanRequest);
            if (foundUser.UserPlans != null)
            {
                List<UserPlan> activePlans = foundUser.UserPlans.Where(up => up.EndDate >= DateTime.Today).ToList();
                if (activePlans.Any())
                {
                    // Get furthest End Date of the user plan and create a plan with that day as startdate
                    DateTime furthestEndDate = foundUser.UserPlans
                        .Where(up => up.EndDate >= DateTime.Today)
                        .Max(up => up.EndDate);
                    userPlan.StartDate = furthestEndDate.AddDays(1);
                    userPlan.EndDate = userPlan.StartDate.AddMonths(1);
                }
            }
            _userPlanRepository.AddUserPlan(userPlan);
        }

    }
}

