using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchWise.Data;
using WatchWise.DTOs.Converters;
using WatchWise.Models;
using WatchWise.Repositories.Interfaces;
using WatchWise.Repositories.Implementations;
using WatchWise.Services.Interfaces;
using WatchWise.Services.Implementations;

namespace WatchWise;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<WatchWiseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("WatchWiseContext") ?? throw new InvalidOperationException("Connection string 'WatchWiseContext' not found.")));

        builder.Services.AddIdentity<WatchWiseUser, WatchWiseRole>()
            .AddEntityFrameworkStores<WatchWiseContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Service Layer
        builder.Services.AddScoped<IUserService,UserService>();
        builder.Services.AddScoped<IDirectorService, DirectorService>();
        builder.Services.AddScoped<IStarService, StarService>();
        builder.Services.AddScoped<IGenreService, GenreService>();
        builder.Services.AddScoped<IPlanService, PlanService>();
        builder.Services.AddScoped<IRestrictionService, RestrictionService>();
        builder.Services.AddScoped<IEpisodeService, EpisodeService>();
        builder.Services.AddScoped<IMediaService, MediaService>();

        builder.Services.AddScoped<IMediaDirectorService, MediaDirectorService>();

        // Repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();
        builder.Services.AddScoped<IMediaRepository, MediaRepository>();
        builder.Services.AddScoped<IPlanRepository, PlanRepository>();
        builder.Services.AddScoped<IRestrictionRepository, RestrictionRepository>();
        builder.Services.AddScoped<IStarRepository, StarRepository>();
        builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();

        builder.Services.AddScoped<IMediaDirectorRepository, MediaDirectorRepository>();
        builder.Services.AddScoped<IMediaGenreRepository, MediaGenreRepository>();
        builder.Services.AddScoped<IMediaRestrictionRepository, MediaRestrictionRepository>();
        builder.Services.AddScoped<IMediaStarRepository, MediaStarRepository>();
        builder.Services.AddScoped<IUserFavoriteRepository, UserFavoriteRepository>();
        builder.Services.AddScoped<IUserPlanRepository, UserPlanRepository>();
        builder.Services.AddScoped<IUserWatchedEpisodeRepository, UserWatchedEpisodeRepository>();

        // Converters-Mappers
        builder.Services.AddScoped<WatchWiseUserConverter>();
        builder.Services.AddScoped<DirectorConverter>();
        builder.Services.AddScoped<StarConverter>();
        builder.Services.AddScoped<GenreConverter>();
        builder.Services.AddScoped<PlanConverter>();
        builder.Services.AddScoped<RestrictionConverter>();
        builder.Services.AddScoped<EpisodeConverter>();
        builder.Services.AddScoped<MediaConverter>();

        builder.Services.AddScoped<MediaDirectorConverter>();
        builder.Services.AddScoped<MediaGenreConverter>();
        builder.Services.AddScoped<MediaRestrictionConverter>();
        builder.Services.AddScoped<MediaStarConverter>();




        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

