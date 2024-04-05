using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IMediaRepository
    {
        IQueryable<Media> GetAllMedia(bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false);
        Media? GetMediaById(int id, bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false);
        Media? GetMediaByName(string name, bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false
            , bool includeUserFavorites = false);
        void AddMedia(Media media);
        void UpdateMedia(Media media);
    }
}