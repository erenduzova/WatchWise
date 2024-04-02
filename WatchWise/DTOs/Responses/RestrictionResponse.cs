using System;
using System.ComponentModel.DataAnnotations;
using WatchWise.Models.CrossTables;

namespace WatchWise.DTOs.Responses
{
	public class RestrictionResponse
	{
        public byte Id { get; set; }
        public string Name { get; set; } = null!;
        public List<MediaRestriction>? MediaRestrictions { get; set; }
    }
}

