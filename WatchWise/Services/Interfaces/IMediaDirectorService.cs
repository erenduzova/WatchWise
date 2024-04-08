using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
	public interface IMediaDirectorService
	{
        List<MediaDirectorResponse> GetAllMediaDirectorResponses();
        List<MediaDirectorResponse> GetMediaDirectorResponsesByMediaId(int id);
        List<MediaDirectorResponse> GetMediaDirectorResponsesByDirectorId(int id);
        void PostMediaDirector(MediaDirectorRequest mediaDirectorRequest);
        int DeleteMediaDirector(MediaDirectorRequest mediaDirectorRequest);
    }
}

