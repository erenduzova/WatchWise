using System;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
	public interface IMediaGenreRepository
	{
        IQueryable<MediaGenre> GetAllMediaGenres();
        IQueryable<MediaGenre> GetMediaGenresByMediaId(int id);
        IQueryable<MediaGenre> GetMediaGenresByGenreId(short id);
        void AddMediaGenre(MediaGenre mediaGenre);
        void DeleteMediaGenre(MediaGenre mediaGenre);
    }
}

