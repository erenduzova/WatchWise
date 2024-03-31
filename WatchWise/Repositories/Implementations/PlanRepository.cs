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

        public IQueryable<Plan> GetAllPlans()
        {
            return _context.Plans;
        }

        public Plan? GetPlanById(short id)
        {
            return _context.Plans.FirstOrDefault(p => p.Id == id);
        }

        public Plan? GetPlanByName(string name)
        {
            return _context.Plans.FirstOrDefault(p => p.Name == name);
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
