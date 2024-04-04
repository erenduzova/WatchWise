using System;
using WatchWise.Models.CrossTables;

namespace WatchWise.Repositories.Interfaces
{
	public interface IMediaRestrictionRepository
	{
        IQueryable<MediaRestriction> GetAllMediaRestrictions();
        MediaRestriction? GetMediaRestrictionByMediaId(int id);
        MediaRestriction? GetMediaRestrictionByRestrictionId(byte id);
        void AddMediaRestriction(MediaRestriction mediaRestriction);
        void DeleteMediaRestriction(MediaRestriction mediaRestriction);
    }
}

