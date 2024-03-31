using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IMediaRepository
    {
        public IQueryable<Media> GetAllMedia(bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false);
        public Media? GetMediaById(int id, bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false);
        public Media? GetMediaByName(string name, bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false);
        public void AddMedia(Media media);
        public void UpdateMedia(Media media);
    }
}