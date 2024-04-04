using System;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
	public interface IMediaGenreRepository
	{
        IQueryable<MediaGenre> GetAllMediaGenres();
        MediaGenre? GetMediaGenreByMediaId(int id);
        MediaGenre? GetMediaGenreByGenreId(short id);
        void AddMediaGenre(MediaGenre mediaGenre);
        void DeleteMediaGenre(MediaGenre mediaGenre);
    }
}

