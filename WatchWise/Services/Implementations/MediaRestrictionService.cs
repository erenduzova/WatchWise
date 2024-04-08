using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models.CrossTables;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
    public class MediaRestrictionService : IMediaRestrictionService
    {
        private readonly IMediaRestrictionRepository _mediaRestrictionRepository;
        private readonly MediaRestrictionConverter _mediaRestrictionConverter;

        public MediaRestrictionService(IMediaRestrictionRepository mediaRestrictionRepository, MediaRestrictionConverter mediaRestrictionConverter)
        {
            _mediaRestrictionRepository = mediaRestrictionRepository;
            _mediaRestrictionConverter = mediaRestrictionConverter;
        }

        public List<MediaRestrictionResponse> GetAllMediaRestrictionResponses()
        {
            IQueryable<MediaRestriction> mediaRestrictions = _mediaRestrictionRepository.GetAllMediaRestrictions();
            return _mediaRestrictionConverter.Convert(mediaRestrictions.AsNoTracking().ToList());
        }

        public List<MediaRestrictionResponse> GetMediaRestrictionResponsesByMediaId(int id)
        {
            IQueryable<MediaRestriction> mediaRestrictions = _mediaRestrictionRepository.GetMediaRestrictionsByMediaId(id);
            return _mediaRestrictionConverter.Convert(mediaRestrictions.AsNoTracking().ToList());
        }

        public List<MediaRestrictionResponse> GetMediaRestrictionResponsesByRestrictionId(byte id)
        {
            IQueryable<MediaRestriction> mediaRestrictions = _mediaRestrictionRepository.GetMediaRestrictionsByRestrictionId(id);
            return _mediaRestrictionConverter.Convert(mediaRestrictions.AsNoTracking().ToList());
        }

        public void PostMediaRestriction(MediaRestrictionRequest mediaRestrictionRequest)
        {
            MediaRestriction newMediaRestriction = _mediaRestrictionConverter.Convert(mediaRestrictionRequest);
            _mediaRestrictionRepository.AddMediaRestriction(newMediaRestriction);
        }

        public int DeleteMediaRestriction(MediaRestrictionRequest mediaRestrictionRequest)
        {
            MediaRestriction? mediaRestriction = _mediaRestrictionRepository.GetMediaRestrictionsByRestrictionId(mediaRestrictionRequest.RestrictionId)
                .Where(mr => mr.MediaId == mediaRestrictionRequest.MediaId).FirstOrDefault();
            if (mediaRestriction == null)
            {
                return -1;
            }
            _mediaRestrictionRepository.DeleteMediaRestriction(mediaRestriction);
            return 1;
        }

    }
}

