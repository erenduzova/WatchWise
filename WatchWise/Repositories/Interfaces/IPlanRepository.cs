using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IPlanRepository
    {
        IQueryable<Plan> GetAllPlans();
        Plan? GetPlanById(short id);
        Plan? GetPlanByName(string name);
        void AddPlan(Plan plan);
        void UpdatePlan(Plan plan);
    }
}