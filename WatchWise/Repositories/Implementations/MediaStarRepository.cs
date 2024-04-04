using System;
using WatchWise.Data;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
	public class MediaStarRepository : IMediaStarRepository
	{
        private readonly WatchWiseContext _context;

        public MediaStarRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<MediaStar> GetAllMediaStars()
        {
            IQueryable<MediaStar> mediaStars = _context.MediaStars;
            return mediaStars;
        }

        public IQueryable<MediaStar> GetMediaStarsByMediaId(int id)
        {
            IQueryable<MediaStar> mediaStars = _context.MediaStars;
            return mediaStars.Where(ms => ms.MediaId == id);
        }

        public IQueryable<MediaStar> GetMediaStarsByStarId(int id)
        {
            IQueryable<MediaStar> mediaStars = _context.MediaStars;
            return mediaStars.Where(ms => ms.StarId == id);
        }

        public void AddMediaStar(MediaStar mediaStar)
        {
            _context.MediaStars.Add(mediaStar);
            _context.SaveChanges();
        }

        public void DeleteMediaStar(MediaStar mediaStar)
        {
            _context.MediaStars.Remove(mediaStar);
            _context.SaveChanges();
        }
    }
}

