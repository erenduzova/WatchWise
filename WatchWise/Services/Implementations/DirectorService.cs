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
    public class DirectorService : IDirectorService
    {

        private readonly IDirectorRepository _directorRepository;
        private readonly DirectorConverter _directorConverter;

        public DirectorService(IDirectorRepository directorRepository, DirectorConverter directorConverter)
        {
            _directorRepository = directorRepository;
            _directorConverter = directorConverter;
        }

        public List<DirectorResponse> GetAllDirectorResponses()
        {
            IQueryable<Director> directors = _directorRepository.GetAllDirectors(includeMedias: true);
            return _directorConverter.Convert(directors.AsNoTracking().ToList());
        }

        public DirectorResponse? GetDirectorResponseById(int id)
        {
            Director? foundDirector = _directorRepository.GetDirectorById(id, includeMedias: true);
            if (foundDirector != null)
            {
                return _directorConverter.Convert(foundDirector);
            }
            return null;
        }

        public void PostDirector(DirectorRequest directorRequest)
        {
            Director newDirector = _directorConverter.Convert(directorRequest);
            _directorRepository.AddDirector(newDirector);
        }

        public int DeleteDirector(int id)
        {
            Director? foundDirector = _directorRepository.GetDirectorById(id);
            if (foundDirector != null)
            {
                _directorRepository.DeleteDirector(foundDirector);
                return 1;
            }
            return -1;
        }

        public int UpdateDirector(int id, DirectorRequest directorRequest)
        {
            Director? foundDirector = _directorRepository.GetDirectorById(id);
            if (foundDirector != null)
            {
                foundDirector.Name = directorRequest.Name;
                _directorRepository.UpdateDirector(foundDirector);
                return 1;
            }
            return -1;
        }
    }
}

