using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.Services.Interfaces
{
    public interface IDirectorService
    {
        List<DirectorResponse> GetAllDirectorResponses();
        DirectorResponse? GetDirectorResponseById(int id);
        void PostDirector(DirectorRequest directorRequest);
        int DeleteDirector(int id);
        int UpdateDirector(int id, DirectorRequest directorRequest);

    }
}

