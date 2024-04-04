using System;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
	public interface IMediaDirectorRepository
	{
        IQueryable<MediaDirector> GetAllMediaDirectors();
        IQueryable<MediaDirector> GetMediaDirectorsByMediaId(int id);
        IQueryable<MediaDirector> GetMediaDirectorsByDirectorId(int id);
        void AddMediaDirector(MediaDirector mediaDirector);
        void DeleteMediaDirector(MediaDirector mediaDirector);
    }
}

