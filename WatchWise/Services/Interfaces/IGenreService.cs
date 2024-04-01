using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
    public interface IGenreService
    {
        List<GenreResponse> GetAllGenreResponses();
        GenreResponse? GetGenreResponseById(short id);
        void PostGenre(GenreRequest genreRequest);
        int UpdateGenre(short id, GenreRequest genreRequest);
    }
}

