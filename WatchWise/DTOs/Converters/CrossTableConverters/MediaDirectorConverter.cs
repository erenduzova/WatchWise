using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.DTOs.Converters
{
	public class MediaDirectorConverter
	{
        public MediaDirector Convert(MediaDirectorRequest mediaDirectorRequest)
        {
            MediaDirector newMediaDirector = new()
            {
                MediaId = mediaDirectorRequest.MediaId,
                DirectorId = mediaDirectorRequest.DirectorId
            };
            return newMediaDirector;
        }

        public MediaDirectorResponse Convert(MediaDirector mediaDirector)
        {
            MediaDirectorResponse mediaDirectorResponse = new()
            {
                MediaId = mediaDirector.MediaId,
                DirectorId = mediaDirector.DirectorId
            };
            return mediaDirectorResponse;
        }

        public List<MediaDirectorResponse> Convert(List<MediaDirector> mediaDirectors)
        {
            List<MediaDirectorResponse> mediaDirectorResponses = new();
            foreach (MediaDirector mediaDirector in mediaDirectors)
            {
                mediaDirectorResponses.Add(Convert(mediaDirector));
            }
            return mediaDirectorResponses;
        }
    }
}

