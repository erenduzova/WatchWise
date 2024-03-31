using Microsoft.EntityFrameworkCore;
using WatchWise.Data;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
    public class MediaRepository : IMediaRepository
    {
        private readonly WatchWiseContext _context;

        public MediaRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<Media> GetAllMedia()
        {
            return _context.Medias;
        }

        public Media? GetMediaById(int id)
        {
            return _context.Medias.FirstOrDefault(m => m.Id == id);
        }

        public Media? GetMediaByName(string name)
        {
            return _context.Medias.FirstOrDefault(m => m.Name == name);
        }

        public void AddMedia(Media media)
        {
            _context.Medias.Add(media);
            _context.SaveChanges();
        }

        public void UpdateMedia(Media media)
        {
            _context.Update(media);
            _context.SaveChanges();
        }
    }
}
