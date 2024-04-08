using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WatchWise.Models;
using WatchWise.Models.CrossTables;

namespace WatchWise.Data
{
    public class WatchWiseContext : IdentityDbContext<WatchWiseUser, WatchWiseRole, long>
    {
        public WatchWiseContext(DbContextOptions<WatchWiseContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; } = default!;
        public DbSet<Star> Stars { get; set; } = default!;
        public DbSet<Director> Directors { get; set; } = default!;
        public DbSet<Media> Medias { get; set; } = default!;
        public DbSet<Episode> Episodes { get; set; } = default!;
        public DbSet<Restriction> Restrictions { get; set; } = default!;
        public DbSet<Plan> Plans { get; set; } = default!;

        public DbSet<MediaStar> MediaStars { get; set; } = default!;
        public DbSet<MediaGenre> MediaGenres { get; set; } = default!;
        public DbSet<MediaDirector> MediaDirectors { get; set; } = default!;
        public DbSet<MediaRestriction> MediaRestrictions { get; set; } = default!;

        public DbSet<UserFavorite> UserFavorites { get; set; } = default!;
        public DbSet<UserPlan> UserPlans { get; set; } = default!;
        public DbSet<UserWatchedEpisode> UserWatchedEpisodes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MediaStar>().HasKey(ms => new { ms.MediaId, ms.StarId });
            builder.Entity<MediaGenre>().HasKey(mg => new { mg.MediaId, mg.GenreId });
            builder.Entity<MediaDirector>().HasKey(md => new { md.MediaId, md.DirectorId });
            builder.Entity<MediaRestriction>().HasKey(mr => new { mr.MediaId, mr.RestrictionId });

            builder.Entity<UserFavorite>().HasKey(uf => new { uf.UserId, uf.MediaId });
            builder.Entity<UserWatchedEpisode>().HasKey(ue => new { ue.UserId, ue.EpisodeId });

            builder.Entity<Episode>().HasIndex(e => new { e.MediaId, e.SeasonNum, e.EpisodeNum }).IsUnique();
            builder.Entity<Plan>().HasIndex(p => p.Name).IsUnique();

            builder.Entity<MediaStar>()
                .HasOne(ms => ms.Media)
                .WithMany(m => m.MediaStars)
                .HasForeignKey(ms => ms.MediaId);
            builder.Entity<MediaStar>()
                .HasOne(ms => ms.Star)
                .WithMany(s => s.MediaStars)
                .HasForeignKey(ms => ms.StarId);

            builder.Entity<MediaGenre>()
                .HasOne(mg => mg.Media)
                .WithMany(m => m.MediaGenres)
                .HasForeignKey(mg => mg.MediaId);
            builder.Entity<MediaGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MediaGenres)
                .HasForeignKey(mg => mg.GenreId);

            builder.Entity<MediaDirector>()
                .HasOne(md => md.Media)
                .WithMany(m => m.MediaDirectors)
                .HasForeignKey(md => md.MediaId);
            builder.Entity<MediaDirector>()
                .HasOne(md => md.Director)
                .WithMany(d => d.MediaDirectors)
                .HasForeignKey(md => md.DirectorId);

            builder.Entity<MediaRestriction>()
                .HasOne(mr => mr.Media)
                .WithMany(m => m.MediaRestrictions)
                .HasForeignKey(mr => mr.MediaId);
            builder.Entity<MediaRestriction>()
                .HasOne(mr => mr.Restriction)
                .WithMany(r => r.MediaRestrictions)
                .HasForeignKey(mr => mr.RestrictionId);

            builder.Entity<UserFavorite>()
                .HasOne(uf => uf.WatchWiseUser)
                .WithMany(u => u.UserFavorites)
                .HasForeignKey(uf => uf.UserId);
            builder.Entity<UserFavorite>()
                .HasOne(uf => uf.Media)
                .WithMany(m => m.UserFavorites)
                .HasForeignKey(uf => uf.MediaId);

            builder.Entity<UserPlan>()
                .HasOne(up => up.WatchWiseUser)
                .WithMany(u => u.UserPlans)
                .HasForeignKey(up => up.UserId);
            builder.Entity<UserPlan>()
                .HasOne(up => up.Plan)
                .WithMany(p => p.UserPlans)
                .HasForeignKey(up => up.PlanId);

            builder.Entity<UserWatchedEpisode>()
                .HasOne(uwe => uwe.WatchWiseUser)
                .WithMany(u => u.UserWatchedEpisodes)
                .HasForeignKey(uwe => uwe.UserId);
            builder.Entity<UserWatchedEpisode>()
                .HasOne(uwe => uwe.Episode)
                .WithMany(e => e.UserWatchedEpisodes)
                .HasForeignKey(uwe => uwe.EpisodeId);
        }

    }
}

