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

        public IQueryable<Restriction> GetAllRestrictions(bool includeMedias = false)
        {
            IQueryable<Restriction> restrictions = _context.Restrictions;
            if (includeMedias)
            {
                restrictions = restrictions.Include(r => r.MediaRestrictions);
            }
            return restrictions;
        }

        public Restriction? GetRestrictionById(byte id, bool includeMedias = false)
        {
            IQueryable<Restriction> restrictions = _context.Restrictions;

            if (includeMedias)
            {
                restrictions = restrictions.Include(r => r.MediaRestrictions);
            }

            return restrictions.FirstOrDefault(r => r.Id == id);
        }

        public Restriction? GetRestrictionByName(string name, bool includeMedias = false)
        {
            IQueryable<Restriction> restrictions = _context.Restrictions;

            if (includeMedias)
            {
                restrictions = restrictions.Include(r => r.MediaRestrictions);
            }

            return restrictions.FirstOrDefault(r => r.Name == name);
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
