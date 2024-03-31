using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IPlanRepository
    {
        IQueryable<Plan> GetAllPlans(bool includeUsers = false);
        Plan? GetPlanById(short id, bool includeUsers = false);
        Plan? GetPlanByName(string name, bool includeUsers = false);
        void AddPlan(Plan plan);
        void UpdatePlan(Plan plan);
    }
}