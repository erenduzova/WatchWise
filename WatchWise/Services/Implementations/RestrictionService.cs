using System;
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
	public class RestrictionService : IRestrictionService
	{
        private readonly IRestrictionRepository _restrictionRepository;
        private readonly RestrictionConverter _restrictionConverter;

        public RestrictionService(IRestrictionRepository restrictionRepository, RestrictionConverter restrictionConverter)
        {
            _restrictionRepository = restrictionRepository;
            _restrictionConverter = restrictionConverter;
        }

        public List<RestrictionResponse> GetAllRestrictionResponses()
        {
            IQueryable<Restriction> restrictions = _restrictionRepository.GetAllRestrictions(includeMedias: true);
            return _restrictionConverter.Convert(restrictions.AsNoTracking().ToList());
        }

        public RestrictionResponse? GetRestrictionResponseById(byte id)
        {
            Restriction? foundRestriction = _restrictionRepository.GetRestrictionById(id, includeMedias: true);
            if (foundRestriction != null)
            {
                return _restrictionConverter.Convert(foundRestriction);
            }
            return null;
        }

        public int PostRestriction(RestrictionRequest restrictionRequest)
        {
            Restriction? foundRestriction = _restrictionRepository.GetRestrictionById(restrictionRequest.Id);
            if (foundRestriction != null)
            {
                return 0;
            }
            Restriction newRestriction = _restrictionConverter.Convert(restrictionRequest);
            _restrictionRepository.AddRestriction(newRestriction);
            return 1;
        }

        public int UpdateRestriction(byte id, RestrictionRequest restrictionRequest)
        {
            Restriction? foundRestriction = _restrictionRepository.GetRestrictionById(id);
            Restriction? newRestriction = _restrictionRepository.GetRestrictionById(restrictionRequest.Id);
            if (newRestriction != null)
            {
                return 0;
            }
            if (foundRestriction != null)
            {
                foundRestriction.Id = restrictionRequest.Id;
                foundRestriction.Name = restrictionRequest.Name;
                _restrictionRepository.UpdateRestriction(foundRestriction);
                return 1;
            }
            return -1;
        }
    }
}

