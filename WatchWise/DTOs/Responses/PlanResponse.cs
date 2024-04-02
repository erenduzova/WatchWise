using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Responses
{
	public class PlanResponse
	{
        public short Id { get; set; }

        public string Name { get; set; } = null!;

        public float Price { get; set; }

        public string MaxResolution { get; set; } = null!;

        public List<UserPlan>? UserPlans { get; set; }
    }
}

