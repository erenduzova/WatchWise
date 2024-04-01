using System;
using System.ComponentModel;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.DTOs.Converters
{
	public class DirectorConverter
	{
        public Director Convert(DirectorRequest directorRequest)
		{
			Director newDirector = new()
			{
				Name = directorRequest.Name,
				MediaDirectors = new List<MediaDirector>()
			};
			return newDirector;
		}

        public DirectorResponse Convert(Director director)
        {
            DirectorResponse directorResponse = new()
            {
				Id = director.Id,
                Name = director.Name,
                MediaDirectors = new List<MediaDirector>()
            };
			if (director.MediaDirectors != null)
			{
                directorResponse.MediaDirectors = director.MediaDirectors;

            }
            return directorResponse;
        }

        public List<DirectorResponse> Convert(List<Director> directors)
        {
            List<DirectorResponse> directorResponses = new();
            foreach (Director director in directors)
            {
                directorResponses.Add(Convert(director));
            }
            return directorResponses;
        }
    }
}

