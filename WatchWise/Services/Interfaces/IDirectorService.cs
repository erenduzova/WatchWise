using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
    public interface IDirectorService
    {
        List<DirectorResponse> GetAllDirectorResponses(bool includeMedia);
        DirectorResponse? GetDirectorResponseById(int id, bool includeMedia);
        int PostDirector(DirectorRequest directorRequest);
        int UpdateDirector(int id, DirectorRequest directorRequest);
        int DeleteDirector(int id);
    }
}

