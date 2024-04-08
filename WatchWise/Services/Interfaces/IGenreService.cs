using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
    public interface IGenreService
    {
        List<GenreResponse> GetAllGenreResponses(bool includeMedia);
        GenreResponse? GetGenreResponseById(short id, bool includeMedia);
        int PostGenre(GenreRequest genreRequest);
        int UpdateGenre(short id, GenreRequest genreRequest);
    }
}

