using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchWise.DTOs.Responses
{
	public class PersonResponse
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}

