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
    public class MediaDirectorService : IMediaDirectorService
    {
        private readonly IMediaDirectorRepository _mediaDirectorRepository;
        private readonly MediaDirectorConverter _mediaDirectorConverter;

        public MediaDirectorService(IMediaDirectorRepository mediaDirectorRepository, MediaDirectorConverter mediaDirectorConverter)
        {
            _mediaDirectorRepository = mediaDirectorRepository;
            _mediaDirectorConverter = mediaDirectorConverter;
        }

        public List<MediaDirectorResponse> GetAllMediaDirectorResponses()
        {
            IQueryable<MediaDirector> mediaDirectors = _mediaDirectorRepository.GetAllMediaDirectors();
            return _mediaDirectorConverter.Convert(mediaDirectors.AsNoTracking().ToList());
        }

        public List<MediaDirectorResponse> GetMediaDirectorResponsesByMediaId(int id)
        {
            IQueryable<MediaDirector> mediaDirectors = _mediaDirectorRepository.GetMediaDirectorsByMediaId(id);
            return _mediaDirectorConverter.Convert(mediaDirectors.AsNoTracking().ToList());
        }

        public List<MediaDirectorResponse> GetMediaDirectorResponsesByDirectorId(int id)
        {
            IQueryable<MediaDirector> mediaDirectors = _mediaDirectorRepository.GetMediaDirectorsByDirectorId(id);
            return _mediaDirectorConverter.Convert(mediaDirectors.AsNoTracking().ToList());
        }

        public void PostMediaDirector(MediaDirectorRequest mediaDirectorRequest)
        {
            MediaDirector newMediaDirector = _mediaDirectorConverter.Convert(mediaDirectorRequest);
            _mediaDirectorRepository.AddMediaDirector(newMediaDirector);
        }

        public int DeleteMediaDirector(MediaDirectorRequest mediaDirectorRequest)
        {
            MediaDirector? mediaDirector = _mediaDirectorRepository.GetMediaDirectorsByDirectorId(mediaDirectorRequest.DirectorId)
                .Where(md => md.MediaId == mediaDirectorRequest.MediaId).FirstOrDefault();
            if (mediaDirector == null)
            {
                return -1;
            }
            _mediaDirectorRepository.DeleteMediaDirector(mediaDirector);
            return 1;
        }
    }
}

