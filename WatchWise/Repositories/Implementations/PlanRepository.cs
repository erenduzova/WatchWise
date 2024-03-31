using Microsoft.EntityFrameworkCore;
using WatchWise.Data;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class PlanRepository : IPlanRepository
    {
        private readonly WatchWiseContext _context;

        public PlanRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<Plan> GetAllPlans(bool includeUsers = false)
        {
            IQueryable<Plan> plans = _context.Plans;
            if (includeUsers)
            {
                plans = plans.Include(p => p.UserPlans);
            }
            return plans;
        }

        public Plan? GetPlanById(short id, bool includeUsers = false)
        {
            IQueryable<Plan> plans = _context.Plans;
            if (includeUsers)
            {
                plans = plans.Include(p => p.UserPlans);
            }
            return plans.FirstOrDefault(p => p.Id == id);
        }

        public Plan? GetPlanByName(string name, bool includeUsers = false)
        {
            IQueryable<Plan> plans = _context.Plans;
            if (includeUsers)
            {
                plans = plans.Include(p => p.UserPlans);
            }
            return plans.FirstOrDefault(p => p.Name == name);
        }

        public void AddPlan(Plan plan)
        {
            _context.Plans.Add(plan);
            _context.SaveChanges();
        }

        public void UpdatePlan(Plan plan)
        {
            _context.Update(plan);
            _context.SaveChanges();
        }
    }
}
