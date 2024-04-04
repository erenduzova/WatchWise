using System;
using WatchWise.Data;
using WatchWise.Models;
using WatchWise.Models.CrossTables;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
	public class MediaRestrictionRepository : IMediaRestrictionRepository
	{
        private readonly WatchWiseContext _context;

        public MediaRestrictionRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<MediaRestriction> GetAllMediaRestrictions()
        {
            IQueryable<MediaRestriction> mediaRestrictions = _context.MediaRestrictions;
            return mediaRestrictions;
        }

        public IQueryable<MediaRestriction> GetMediaRestrictionsByMediaId(int id)
        {
            IQueryable<MediaRestriction> mediaRestrictions = _context.MediaRestrictions;
            return mediaRestrictions.Where(mr => mr.MediaId == id);
        }

        public IQueryable<MediaRestriction> GetMediaRestrictionsByRestrictionId(byte id)
        {
            IQueryable<MediaRestriction> mediaRestrictions = _context.MediaRestrictions;
            return mediaRestrictions.Where(mr => mr.RestrictionId == id);
        }

        public void AddMediaRestriction(MediaRestriction mediaRestriction)
        {
            _context.MediaRestrictions.Add(mediaRestriction);
            _context.SaveChanges();
        }

        public void DeleteMediaRestriction(MediaRestriction mediaRestriction)
        {
            _context.MediaRestrictions.Remove(mediaRestriction);
            _context.SaveChanges();
        }
    }
}

