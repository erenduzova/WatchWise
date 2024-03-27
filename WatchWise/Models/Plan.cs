using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchWise.Models.CrossTables;

namespace WatchWise.Models
{
	public class Plan
	{
		public short Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Column(TypeName = "nvarchar(50)")]
        public required string Name { get; set; }

		[Range(0, float.MaxValue)]
		public required float Price { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [Column(TypeName = "varchar(20)")]
        public required string MaxResolution { get; set; }

        public List<UserPlan>? UserPlans;
	}
}

