﻿namespace WatchWise.DTOs.Responses
{
    public class WatchWiseUserResponse
    {
        public long Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public bool Passive { get; set; }
        public List<short>? PlanIds { get; set; }
        public List<int>? FavoriteMediaIds { get; set; }
        public List<long>? WatchedEpisodeIds { get; set; }
    }
}
