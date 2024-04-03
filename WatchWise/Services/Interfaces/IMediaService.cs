using System;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;

namespace WatchWise.Services.Interfaces
{
	public interface IMediaService
	{
        List<MediaResponse> GetAllMediaResponses();
        MediaResponse? GetMediaResponseById(int id);
        void PostMedia(MediaRequest mediaRequest);
        int UpdateMedia(int id, MediaRequest mediaRequest);
        int DeleteMedia(int id);
    }
}

