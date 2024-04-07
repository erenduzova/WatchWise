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
        builder.Services.AddScoped<IMediaGenreService, MediaGenreService>();
        builder.Services.AddScoped<IMediaStarService, MediaStarService>();
        builder.Services.AddScoped<IMediaRestrictionService, MediaRestrictionService>();
        builder.Services.AddScoped<IUserFavoriteService, UserFavoriteService>();
        builder.Services.AddScoped<IUserWatchedEpisodeService, UserWatchedEpisodeService>();
        builder.Services.AddScoped<IUserPlanService, UserPlanService>();

        // Repositories
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IDirectorRepository, DirectorRepository>();
        builder.Services.AddTransient<IGenreRepository, GenreRepository>();
        builder.Services.AddTransient<IMediaRepository, MediaRepository>();
        builder.Services.AddTransient<IPlanRepository, PlanRepository>();
        builder.Services.AddTransient<IRestrictionRepository, RestrictionRepository>();
        builder.Services.AddTransient<IStarRepository, StarRepository>();
        builder.Services.AddTransient<IEpisodeRepository, EpisodeRepository>();

        builder.Services.AddTransient<IMediaDirectorRepository, MediaDirectorRepository>();
        builder.Services.AddTransient<IMediaGenreRepository, MediaGenreRepository>();
        builder.Services.AddTransient<IMediaRestrictionRepository, MediaRestrictionRepository>();
        builder.Services.AddTransient<IMediaStarRepository, MediaStarRepository>();
        builder.Services.AddTransient<IUserFavoriteRepository, UserFavoriteRepository>();
        builder.Services.AddTransient<IUserPlanRepository, UserPlanRepository>();
        builder.Services.AddTransient<IUserWatchedEpisodeRepository, UserWatchedEpisodeRepository>();

        // Converters-Mappers
        builder.Services.AddTransient<WatchWiseUserConverter>();
        builder.Services.AddTransient<DirectorConverter>();
        builder.Services.AddTransient<StarConverter>();
        builder.Services.AddTransient<GenreConverter>();
        builder.Services.AddTransient<PlanConverter>();
        builder.Services.AddTransient<RestrictionConverter>();
        builder.Services.AddTransient<EpisodeConverter>();
        builder.Services.AddTransient<MediaConverter>();

        builder.Services.AddTransient<MediaDirectorConverter>();
        builder.Services.AddTransient<MediaGenreConverter>();
        builder.Services.AddTransient<MediaRestrictionConverter>();
        builder.Services.AddTransient<MediaStarConverter>();
        builder.Services.AddTransient<UserFavoriteConverter>();
        builder.Services.AddTransient<UserPlanConverter>();
        builder.Services.AddTransient<UserWatchedEpisodeConverter>();



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

        WatchWiseContext? watchWiseContext = app.Services.CreateScope().ServiceProvider.GetService<WatchWiseContext>(); 
        UserManager<WatchWiseUser>? userManager = app.Services.CreateScope().ServiceProvider.GetService<UserManager<WatchWiseUser>>();
        RoleManager<WatchWiseRole>? roleManager = app.Services.CreateScope().ServiceProvider.GetService<RoleManager<WatchWiseRole>>();
        if (watchWiseContext != null && userManager != null && roleManager != null)
        {
            DbInitializer dbInitializer = new DbInitializer(watchWiseContext, userManager, roleManager);
            dbInitializer.Initialize();
        }

        app.Run();
    }
}

