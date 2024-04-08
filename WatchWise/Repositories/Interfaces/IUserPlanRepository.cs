using WatchWise.Models.CrossTables;

namespace WatchWise.Repositories.Interfaces
{
    public interface IUserPlanRepository
    {
        IQueryable<UserPlan> GetAllUserPlans();
        UserPlan? GetUserPlanById(long id);
        IQueryable<UserPlan> GetUserPlansByUserId(long userId);
        IQueryable<UserPlan> GetUserPlansByPlanId(short planId);
        void AddUserPlan(UserPlan userPlan);
    }
}

