using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.Services.Interfaces
{
	public interface IMediaStarService
	{
        List<MediaStarResponse> GetAllMediaStarResponses();
        List<MediaStarResponse> GetMediaStarResponsesByMediaId(int id);
        List<MediaStarResponse> GetMediaStarResponsesByStarId(int id);
        void PostMediaStar(MediaStarRequest mediaStarRequest);
        void DeleteMediaStar(MediaStar mediaStar);
    }
}

