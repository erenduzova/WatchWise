using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Repositories.Implementations;
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

        public List<GenreResponse> GetAllGenreResponses(bool includeMedia)
        {
            IQueryable<Genre> genres = _genreRepository.GetAllGenres(includeMedia);
            return _genreConverter.Convert(genres.AsNoTracking().ToList());
        }

        public GenreResponse? GetGenreResponseById(short id, bool includeMedia)
        {
            Genre? foundGenre = _genreRepository.GetGenreById(id, includeMedia);
            if (foundGenre != null)
            {
                return _genreConverter.Convert(foundGenre);
            }
            return null;
        }

        public int PostGenre(GenreRequest genreRequest)
        {
            Genre newGenre = _genreConverter.Convert(genreRequest);
            if (!_genreRepository.GetAllGenres().Any(g => g.Name == newGenre.Name))
            {
                _genreRepository.AddGenre(newGenre);
                return 1;
            }
            return -1;
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

