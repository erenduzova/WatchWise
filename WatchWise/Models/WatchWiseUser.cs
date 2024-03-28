using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using WatchWise.Models.CrossTables;

namespace WatchWise.Models
{
	public class WatchWiseUser : IdentityUser<long>
	{

        [StringLength(100, MinimumLength = 2)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = "";

		[Column(TypeName = "date")]
		public DateTime BirthDate { get; set; }

        public bool Passive { get; set; }

        public List<UserWatchedEpisode>? UserWatchedEpisodes { get; set; }
        public List<UserFavorite>? UserFavorites { get; set; }
        public List<UserPlan>? UserPlans;
    }
}

