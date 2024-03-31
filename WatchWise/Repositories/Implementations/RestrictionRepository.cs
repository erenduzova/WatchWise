using Microsoft.EntityFrameworkCore;
using WatchWise.Data;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class RestrictionRepository : IRestrictionRepository
    {
        private readonly WatchWiseContext _context;

        public RestrictionRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<Restriction> GetAllRestrictions()
        {
            return _context.Restrictions;
        }

        public Restriction? GetRestrictionById(byte id)
        {
            return _context.Restrictions.FirstOrDefault(r => r.Id == id);
        }

        public Restriction? GetRestrictionByName(string name)
        {
            return _context.Restrictions.FirstOrDefault(r => r.Name == name);
        }

        public void AddRestriction(Restriction restriction)
        {
            _context.Restrictions.Add(restriction);
            _context.SaveChanges();
        }

        public void UpdateRestriction(Restriction restriction)
        {
            _context.Update(restriction);
            _context.SaveChanges();
        }
    }
}
