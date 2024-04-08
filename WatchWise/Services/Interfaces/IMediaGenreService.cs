using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
	public interface IMediaGenreService
    {
        List<MediaGenreResponse> GetAllMediaGenreResponses();
        List<MediaGenreResponse> GetMediaGenreResponsesByMediaId(int id);
        List<MediaGenreResponse> GetMediaGenreResponsesByGenreId(short id);
        void PostMediaGenre(MediaGenreRequest mediaGenreRequest);
        int DeleteMediaGenre(MediaGenreRequest mediaGenreRequest);
    }
}

