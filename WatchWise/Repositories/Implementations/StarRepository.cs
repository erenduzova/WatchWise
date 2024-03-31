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

        public IQueryable<Star> GetAllStars()
        {
            return _context.Stars;
        }

        public Star? GetStarById(int id)
        {
            return _context.Stars.FirstOrDefault(s => s.Id == id);
        }

        public void AddStar(Star star)
        {
            _context.Stars.Add(star);
        }

        public Star? GetStarByName(string name)
        {
            return _context.Stars.FirstOrDefault(s => s.Name == name);
        }

        public void DeleteStar(Star star)
        {
            _context.Stars.Remove(star);
        }
    }
}
