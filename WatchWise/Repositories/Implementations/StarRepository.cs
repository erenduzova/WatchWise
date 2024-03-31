using Microsoft.EntityFrameworkCore;
using WatchWise.Data;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class StarRepository : IStarRepository
    {
        private readonly WatchWiseContext _context;

        public StarRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<Star> GetAllStars(bool includeMedia = false)
        {
            IQueryable<Star> stars = _context.Stars;

            if (includeMedia)
            {
                stars = stars.Include(s => s.MediaStars);
            }
            return stars;
        }

        public Star? GetStarById(int id, bool includeMedia = false)
        {
            IQueryable<Star> stars = _context.Stars;

            if (includeMedia)
            {
                stars = stars.Include(s => s.MediaStars);
            }

            return stars.FirstOrDefault(s => s.Id == id);
        }

        public Star? GetStarByName(string name, bool includeMedia = false)
        {
            IQueryable<Star> stars = _context.Stars;

            if (includeMedia)
            {
                stars = stars.Include(s => s.MediaStars);
            }

            return stars.FirstOrDefault(s => s.Name == name);
        }

        public void AddStar(Star star)
        {
            _context.Stars.Add(star);
        }

        public void DeleteStar(Star star)
        {
            _context.Stars.Remove(star);
        }
    }
}
