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
                Name = directorRequest.Name
            };
            return newDirector;
        }

        public DirectorResponse Convert(Director director)
        {
            DirectorResponse directorResponse = new()
            {
                Id = director.Id,
                Name = director.Name,
                MediaIds = new List<int>()
            };
            if (director.MediaDirectors != null)
            {
                directorResponse.MediaIds = director.MediaDirectors.Select(ms => ms.MediaId).ToList();

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

