using System;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
	public interface IMediaStarRepository
	{
        IQueryable<MediaStar> GetAllMediaStars();
        MediaStar? GetMediaStarByMediaId(int id);
        MediaStar? GetMediaStarByStarId(int id);
        void AddMediaStar(MediaStar mediaStar);
        void DeleteMediaStar(MediaStar mediaStar);
    }
}

