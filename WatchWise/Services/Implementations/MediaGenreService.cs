using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
	public class MediaGenreService : IMediaGenreService
	{
        private readonly IMediaGenreRepository _mediaGenreRepository;
        private readonly MediaGenreConverter _mediaGenreConverter;

        public MediaGenreService(IMediaGenreRepository mediaGenreRepository, MediaGenreConverter mediaGenreConverter)
        {
            _mediaGenreRepository = mediaGenreRepository;
            _mediaGenreConverter = mediaGenreConverter;
        }

        public List<MediaGenreResponse> GetAllMediaGenreResponses()
        {
            IQueryable<MediaGenre> mediaGenres = _mediaGenreRepository.GetAllMediaGenres();
            return _mediaGenreConverter.Convert(mediaGenres.AsNoTracking().ToList());
        }

        public List<MediaGenreResponse> GetMediaGenreResponsesByMediaId(int id)
        {
            IQueryable<MediaGenre> mediaGenres = _mediaGenreRepository.GetMediaGenresByMediaId(id);
            return _mediaGenreConverter.Convert(mediaGenres.AsNoTracking().ToList());
        }

        public List<MediaGenreResponse> GetMediaGenreResponsesByGenreId(short id)
        {
            IQueryable<MediaGenre> mediaGenres = _mediaGenreRepository.GetMediaGenresByGenreId(id);
            return _mediaGenreConverter.Convert(mediaGenres.AsNoTracking().ToList());
        }

        public void PostMediaGenre(MediaGenreRequest mediaGenreRequest)
        {
            MediaGenre newMediaGenre = _mediaGenreConverter.Convert(mediaGenreRequest);
            _mediaGenreRepository.AddMediaGenre(newMediaGenre);
        }

        public int DeleteMediaGenre(MediaGenreRequest mediaGenreRequest)
        {
            MediaGenre? mediaGenre = _mediaGenreRepository.GetMediaGenresByGenreId(mediaGenreRequest.GenreId)
                .Where(mg => mg.MediaId == mediaGenreRequest.MediaId).FirstOrDefault();
            if (mediaGenre == null)
            {
                return -1;
            }
            _mediaGenreRepository.DeleteMediaGenre(mediaGenre);
            return 1;
        }
    }
}

