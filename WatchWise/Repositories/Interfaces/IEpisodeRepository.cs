﻿using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

namespace WatchWise.Repositories.Interfaces
{
    public interface IEpisodeRepository
    {
        IQueryable<Episode> GetAllEpisodes(bool includeUserWatchedEpisodes = false);
        Episode? GetEpisodeById(long id, bool includeMediaGenres = false);
        void AddEpisode(Episode episode);
        void UpdateEpisode(Episode episode);
    }
}