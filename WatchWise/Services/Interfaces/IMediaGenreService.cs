using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.Services.Interfaces
{
	public interface IMediaGenreService
    {
        List<MediaGenreResponse> GetAllMediaGenreResponses();
        List<MediaGenreResponse> GetMediaGenreResponsesByMediaId(int id);
        List<MediaGenreResponse> GetMediaGenreResponsesByGenreId(short id);
        void PostMediaGenre(MediaGenreRequest mediaGenreRequest);
        void DeleteMediaGenre(MediaGenre mediaGenre);
    }
}

