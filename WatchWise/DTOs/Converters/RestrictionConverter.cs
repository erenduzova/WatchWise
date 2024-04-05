using System;
using System.Numerics;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Converters
{
	public class RestrictionConverter
	{
        public Restriction Convert(RestrictionRequest restrictionRequest)
        {
            Restriction newRestriction = new()
            {
                Id = restrictionRequest.Id,
                Name = restrictionRequest.Name
            };
            return newRestriction;
        }

        public RestrictionResponse Convert(Restriction restriction)
        {
            RestrictionResponse restrictionResponse = new()
            {
                Id = restriction.Id,
                Name = restriction.Name,
                MediaRestrictions = new List<MediaRestriction>()
            };
            if (restriction.MediaRestrictions != null)
            {
                restrictionResponse.MediaRestrictions = restriction.MediaRestrictions;
            }
            return restrictionResponse;
        }

        public List<RestrictionResponse> Convert(List<Restriction> restrictions)
        {
            List<RestrictionResponse> restrictionResponses = new();
            foreach (Restriction restriction in restrictions)
            {
                restrictionResponses.Add(Convert(restriction));
            }
            return restrictionResponses;
        }
    }
}

