using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.DTOs.Converters
{
    public class MediaGenreConverter
    {
        public MediaGenre Convert(MediaGenreRequest mediaGenreRequest)
        {
            MediaGenre newMediaGenre = new()
            {
                MediaId = mediaGenreRequest.MediaId,
                GenreId = mediaGenreRequest.GenreId
            };
            return newMediaGenre;
        }

        public MediaGenreResponse Convert(MediaGenre mediaGenre)
        {
            MediaGenreResponse mediaGenreResponse = new()
            {
                MediaId = mediaGenre.MediaId,
                GenreId = mediaGenre.GenreId
            };
            return mediaGenreResponse;
        }

        public List<MediaGenreResponse> Convert(List<MediaGenre> mediaGenres)
        {
            List<MediaGenreResponse> mediaGenreResponses = new();
            foreach (MediaGenre mediaGenre in mediaGenres)
            {
                mediaGenreResponses.Add(Convert(mediaGenre));
            }
            return mediaGenreResponses;
        }
    }
}

