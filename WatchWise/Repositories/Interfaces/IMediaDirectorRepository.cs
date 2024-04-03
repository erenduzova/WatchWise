using System;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
	public interface IMediaDirectorRepository
	{
        IQueryable<MediaDirector> GetAllMediaDirectors();
        MediaDirector? GetMediaDirectorByMediaId(int id);
        MediaDirector? GetMediaDirectorByDirectorId(int id);
        void AddMediaDirector(MediaDirector mediaDirector);
        void DeleteMediaDirector(MediaDirector mediaDirector);
    }
}

