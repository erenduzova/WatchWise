using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
    public interface IMediaStarService
    {
        List<MediaStarResponse> GetAllMediaStarResponses();
        List<MediaStarResponse> GetMediaStarResponsesByMediaId(int id);
        List<MediaStarResponse> GetMediaStarResponsesByStarId(int id);
        void PostMediaStar(MediaStarRequest mediaStarRequest);
        int DeleteMediaStar(MediaStarRequest mediaStarRequest);
    }
}

