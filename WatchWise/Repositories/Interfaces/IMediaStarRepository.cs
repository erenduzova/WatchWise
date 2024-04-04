using System;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
	public interface IMediaStarRepository
	{
        IQueryable<MediaStar> GetAllMediaStars();
        IQueryable<MediaStar> GetMediaStarsByMediaId(int id);
        IQueryable<MediaStar> GetMediaStarsByStarId(int id);
        void AddMediaStar(MediaStar mediaStar);
        void DeleteMediaStar(MediaStar mediaStar);
    }
}

