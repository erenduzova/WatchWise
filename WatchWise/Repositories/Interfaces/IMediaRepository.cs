using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IMediaRepository
    {
        public IQueryable<Media> GetAllMedia();
        public Media? GetMediaById(int id);
        public Media? GetMediaByName(string name);
        public void AddMedia(Media media);
        public void UpdateMedia(Media media);
    }
}