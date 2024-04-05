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

        private IQueryable<Media> IncludeRelatedObjects(IQueryable<Media> medias
            , bool includeMediaGenres
            , bool includeMediaStars
            , bool includeMediaDirectors
            , bool includeMediaRestrictions
            , bool includeUserFavorites)
        {
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

        public IQueryable<Media> GetAllMedia(bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false)
        {
            IQueryable<Media> medias = _context.Medias;
            medias = IncludeRelatedObjects(medias, includeMediaGenres
                , includeMediaStars
                , includeMediaDirectors
                , includeMediaRestrictions
                , includeUserFavorites);
            return medias;
        }

        public Media? GetMediaById(int id
            , bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false)
        {
            IQueryable<Media> medias = _context.Medias;
            medias = IncludeRelatedObjects(medias, includeMediaGenres
                , includeMediaStars
                , includeMediaDirectors
                , includeMediaRestrictions
                , includeUserFavorites);
            return medias.FirstOrDefault(m => m.Id == id);
        }

        public Media? GetMediaByName(string name
            , bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false)
        {
            IQueryable<Media> medias = _context.Medias;
            medias = IncludeRelatedObjects(medias
                , includeMediaGenres
                , includeMediaStars
                , includeMediaDirectors
                , includeMediaRestrictions
                , includeUserFavorites);
            return medias.FirstOrDefault(m => m.Name == name);
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
