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

        public IQueryable<Media> GetAllMedia(bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false)
        {
            IQueryable<Media> medias = _context.Medias;
            if (includeMediaGenres)
            {
                medias = medias.Include(m => m.MediaGenres);
            }
            if (includeMediaStars)
            {
                medias = medias.Include(m => m.MediaStars);
            }
            if (includeMediaDirectors)
            {
                medias = medias.Include(m => m.MediaDirectors);
            }
            if (includeMediaRestrictions)
            {
                medias = medias.Include(m => m.MediaRestrictions);
            }
            if (includeUserFavorites)
            {
                medias = medias.Include(m => m.UserFavorites);
            }
            return medias;
        }

        public Media? GetMediaById(int id
            , bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false)
        {
            IQueryable<Media> media = _context.Medias;
            if (includeMediaGenres)
            {
                media = media.Include(m => m.MediaGenres);
            }
            if (includeMediaStars)
            {
                media = media.Include(m => m.MediaStars);
            }
            if (includeMediaDirectors)
            {
                media = media.Include(m => m.MediaDirectors);
            }
            if (includeMediaRestrictions)
            {
                media = media.Include(m => m.MediaRestrictions);
            }
            if (includeUserFavorites)
            {
                media = media.Include(m => m.UserFavorites);
            }
            return media.FirstOrDefault(m => m.Id == id);
        }

        public Media? GetMediaByName(string name
            , bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false)
        {
            IQueryable<Media> media = _context.Medias;
            if (includeMediaGenres)
            {
                media = media.Include(m => m.MediaGenres);
            }
            if (includeMediaStars)
            {
                media = media.Include(m => m.MediaStars);
            }
            if (includeMediaDirectors)
            {
                media = media.Include(m => m.MediaDirectors);
            }
            if (includeMediaRestrictions)
            {
                media = media.Include(m => m.MediaRestrictions);
            }
            if (includeUserFavorites)
            {
                media = media.Include(m => m.UserFavorites);
            }
            return media.FirstOrDefault(m => m.Name == name);
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
