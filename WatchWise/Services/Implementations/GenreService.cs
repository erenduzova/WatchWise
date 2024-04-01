using System;
using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly GenreConverter _genreConverter;

        public GenreService(IGenreRepository genreRepository, GenreConverter genreConverter)
        {
            _genreRepository = genreRepository;
            _genreConverter = genreConverter;
        }

        public List<GenreResponse> GetAllGenreResponses()
        {
            IQueryable<Genre> genres = _genreRepository.GetAllGenres(includeMediaGenres: true);
            return _genreConverter.Convert(genres.AsNoTracking().ToList());
        }

        public GenreResponse? GetGenreResponseById(short id)
        {
            Genre? foundGenre = _genreRepository.GetGenreById(id, includeMediaGenres: true);
            if (foundGenre != null)
            {
                return _genreConverter.Convert(foundGenre);
            }
            return null;
        }

        public void PostGenre(GenreRequest genreRequest)
        {
            Genre newGenre = _genreConverter.Convert(genreRequest);
            _genreRepository.AddGenre(newGenre);
        }

        public int UpdateGenre(short id, GenreRequest genreRequest)
        {
            Genre? genre = _genreRepository.GetGenreById(id);
            if (genre != null)
            {
                genre.Name = genreRequest.Name;
                _genreRepository.UpdateGenre(genre);
                return 1;
            }
            return -1;
        }
    }
}

