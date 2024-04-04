using System;
using WatchWise.Data;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;

namespace WatchWise.Repositories.Implementations
{
	public class MediaGenreRepository : IMediaGenreRepository
	{
        private readonly WatchWiseContext _context;

        public MediaGenreRepository(WatchWiseContext context)
        {
            _context = context;
        }

        public IQueryable<MediaGenre> GetAllMediaGenres()
        {
            IQueryable<MediaGenre> mediaGenres = _context.MediaGenres;
            return mediaGenres;
        }

        public MediaGenre? GetMediaGenreByMediaId(int id)
        {
            IQueryable<MediaGenre> mediaGenres = _context.MediaGenres;
            return mediaGenres.FirstOrDefault(mg => mg.MediaId == id);
        }

        public MediaGenre? GetMediaGenreByGenreId(short id)
        {
            IQueryable<MediaGenre> mediaGenres = _context.MediaGenres;
            return mediaGenres.FirstOrDefault(mg => mg.GenreId == id);
        }

        public void AddMediaGenre(MediaGenre mediaGenre)
        {
            _context.MediaGenres.Add(mediaGenre);
            _context.SaveChanges();
        }

        public void DeleteMediaGenre(MediaGenre mediaGenre)
        {
            _context.MediaGenres.Remove(mediaGenre);
            _context.SaveChanges();
        }
    }
}

