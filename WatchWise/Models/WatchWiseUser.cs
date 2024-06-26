﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using WatchWise.Models.CrossTables;

namespace WatchWise.Models
{
    public class WatchWiseUser : IdentityUser<long>
    {

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = "";

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public bool Passive { get; set; }

        public virtual List<UserWatchedEpisode>? UserWatchedEpisodes { get; set; }
        public virtual List<UserFavorite>? UserFavorites { get; set; }
        public virtual List<UserPlan>? UserPlans { get; set; }
    }
}

