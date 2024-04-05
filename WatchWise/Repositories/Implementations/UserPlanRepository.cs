using System;
using WatchWise.Data;
using WatchWise.Models.CrossTables;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
	public class UserPlanRepository : IUserPlanRepository
	{
        private readonly WatchWiseContext _context;

        public UserPlanRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<UserPlan> GetAllUserPlans()
        {
            IQueryable<UserPlan> userPlans = _context.UserPlans;
            return userPlans;
        }

        public UserPlan? GetUserPlanById(long id)
        {
            IQueryable<UserPlan> userPlans = _context.UserPlans;
            return userPlans.FirstOrDefault(up => up.Id == id);
        }

        public IQueryable<UserPlan> GetUserPlansByUserId(long userId)
        {
            IQueryable<UserPlan> userPlans = _context.UserPlans;
            return _context.UserPlans.Where(up => up.UserId == userId);
        }

        public IQueryable<UserPlan> GetUserPlansByPlanId(short planId)
        {
            IQueryable<UserPlan> userPlans = _context.UserPlans;
            return _context.UserPlans.Where(up => up.PlanId == planId);
        }

        public void AddUserPlan(UserPlan userPlan)
        {
            _context.UserPlans.Add(userPlan);
            _context.SaveChanges();
        }

    }
}

