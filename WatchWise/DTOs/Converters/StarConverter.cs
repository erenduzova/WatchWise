using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.DTOs.Converters
{
	public class StarConverter
	{
        public Star Convert(StarRequest starRequest)
        {
            Star newStar = new()
            {
                Name = starRequest.Name
            };
            return newStar;
        }

        public StarResponse Convert(Star star)
        {
            StarResponse starResponse = new()
            {
                Id = star.Id,
                Name = star.Name,
                MediaIds = new List<int>()
            };
            if (star.MediaStars != null)
            {
                starResponse.MediaIds = star.MediaStars.Select(ms => ms.MediaId).ToList();
            }
            return starResponse;
        }

        public List<StarResponse> Convert(List<Star> stars)
        {
            List<StarResponse> starResponses = new();
            foreach (Star star in stars)
            {
                starResponses.Add(Convert(star));
            }
            return starResponses;
        }

    }
}

