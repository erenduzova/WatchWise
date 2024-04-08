using WatchWise.Data;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class MediaDirectorRepository : IMediaDirectorRepository
    {
        private readonly WatchWiseContext _context;

        public MediaDirectorRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<MediaDirector> GetAllMediaDirectors()
        {
            IQueryable<MediaDirector> mediaDirectors = _context.MediaDirectors;
            return mediaDirectors;
        }

        public IQueryable<MediaDirector> GetMediaDirectorsByMediaId(int id)
        {
            IQueryable<MediaDirector> mediaDirectors = _context.MediaDirectors;
            return mediaDirectors.Where(md => md.MediaId == id);
        }

        public IQueryable<MediaDirector> GetMediaDirectorsByDirectorId(int id)
        {
            IQueryable<MediaDirector> mediaDirectors = _context.MediaDirectors;
            return mediaDirectors.Where(md => md.DirectorId == id);
        }

        public void AddMediaDirector(MediaDirector mediaDirector)
        {
            _context.MediaDirectors.Add(mediaDirector);
            _context.SaveChanges();
        }

        public void DeleteMediaDirector(MediaDirector mediaDirector)
        {
            _context.MediaDirectors.Remove(mediaDirector);
            _context.SaveChanges();
        }
    }
}

