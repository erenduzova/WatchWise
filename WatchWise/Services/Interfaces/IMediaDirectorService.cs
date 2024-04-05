using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.Services.Interfaces
{
	public interface IMediaDirectorService
	{
        List<MediaDirectorResponse> GetAllMediaDirectorResponses();
        List<MediaDirectorResponse> GetMediaDirectorResponsesByMediaId(int id);
        List<MediaDirectorResponse> GetMediaDirectorResponsesByDirectorId(int id);
        void PostMediaDirector(MediaDirectorRequest mediaDirectorRequest);
        void DeleteMediaDirector(MediaDirector mediaDirector);
    }
}

