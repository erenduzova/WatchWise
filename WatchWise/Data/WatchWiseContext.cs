using System;
using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

namespace WatchWise.Data
{
	public class WatchWiseContext : DbContext
	{
		public WatchWiseContext(DbContextOptions<WatchWiseContext> options) : base(options)
		{
		}

		public DbSet<Genre>? Genres { get; set; } = default!;

	}
}

