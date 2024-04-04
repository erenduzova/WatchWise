using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WatchWise.Models;

namespace WatchWise.DTOs.Requests
{
	public class UserPlanRequest
	{
        public long Id { get; set; }
        public long UserId { get; set; }
        public short PlanId { get; set; }
    }
}

