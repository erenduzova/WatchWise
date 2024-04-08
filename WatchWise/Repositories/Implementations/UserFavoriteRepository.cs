using WatchWise.Data;
using WatchWise.Models.CrossTables;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class UserFavoriteRepository : IUserFavoriteRepository
    {
        private readonly WatchWiseContext _context;

        public UserFavoriteRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<UserFavorite> GetAllUserFavorites()
        {
            IQueryable<UserFavorite> userFavorites = _context.UserFavorites;
            return userFavorites;
        }

        public IQueryable<UserFavorite> GetUserFavoritesByUserId(long userId)
        {
            IQueryable<UserFavorite> userFavorites = _context.UserFavorites;
            return userFavorites.Where(uf => uf.UserId == userId);
        }

        public IQueryable<UserFavorite> GetUserFavoritesByMediaId(int mediaId)
        {
            IQueryable<UserFavorite> userFavorites = _context.UserFavorites;
            return userFavorites.Where(uf => uf.MediaId == mediaId);
        }

        public void AddUserFavorite(UserFavorite userFavorite)
        {
            _context.UserFavorites.Add(userFavorite);
            _context.SaveChanges();
        }

        public void DeleteUserFavorite(UserFavorite userFavorite)
        {
            _context.UserFavorites.Remove(userFavorite);
            _context.SaveChanges();
        }
    }
}

