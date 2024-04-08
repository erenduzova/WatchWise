using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
    public interface IMediaService
    {
        List<MediaResponse> GetAllMediaResponses(bool includeMediaGenres
            , bool includeMediaStars
            , bool includeMediaDirectors
            , bool includeMediaRestrictions);
        MediaResponse? GetMediaResponseById(int id, bool includeMediaGenres
            , bool includeMediaStars
            , bool includeMediaDirectors
            , bool includeMediaRestrictions);
        void PostMedia(MediaRequest mediaRequest);
        int UpdateMedia(int id, MediaRequest mediaRequest);
        int DeleteMedia(int id);
    }
}

