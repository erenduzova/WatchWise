using WatchWise.Models.CrossTables;

namespace WatchWise.Repositories.Interfaces
{
    public interface IMediaRestrictionRepository
    {
        IQueryable<MediaRestriction> GetAllMediaRestrictions();
        IQueryable<MediaRestriction> GetMediaRestrictionsByMediaId(int id);
        IQueryable<MediaRestriction> GetMediaRestrictionsByRestrictionId(byte id);
        void AddMediaRestriction(MediaRestriction mediaRestriction);
        void DeleteMediaRestriction(MediaRestriction mediaRestriction);
    }
}

