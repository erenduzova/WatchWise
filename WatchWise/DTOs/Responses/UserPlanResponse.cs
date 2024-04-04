﻿using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WatchWise.Models;

namespace WatchWise.DTOs.Responses
{
	public class UserPlanResponse
	{
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public short PlanId { get; set; }
    }
}

