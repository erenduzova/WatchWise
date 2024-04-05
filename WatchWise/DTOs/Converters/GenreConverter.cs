using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.DTOs.Converters
{
	public class GenreConverter
	{
        public Genre Convert(GenreRequest genreRequest)
        {
            Genre newGenre = new()
            {
                Name = genreRequest.Name
            };
            return newGenre;
        }

        public GenreResponse Convert(Genre genre)
        {
            GenreResponse genreResponse = new()
            {
                Id = genre.Id,
                Name = genre.Name,
                MediaIds = new List<int>()
            };
            if (genre.MediaGenres != null)
            {
                genreResponse.MediaIds = genre.MediaGenres.Select(ms => ms.MediaId).ToList();

            }
            return genreResponse;
        }

        public List<GenreResponse> Convert(List<Genre> genres)
        {
            List<GenreResponse> genreResponse = new();
            foreach (Genre genre in genres)
            {
                genreResponse.Add(Convert(genre));
            }
            return genreResponse;
        }

    }
}

