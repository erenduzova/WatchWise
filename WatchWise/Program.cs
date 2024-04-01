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

        // Repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();
        builder.Services.AddScoped<IMediaRepository, MediaRepository>();
        builder.Services.AddScoped<IPlanRepository, PlanRepository>();
        builder.Services.AddScoped<IRestrictionRepository, RestrictionRepository>();
        builder.Services.AddScoped<IStarRepository, StarRepository>();
        builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();

        // Converters-Mappers
        builder.Services.AddScoped<WatchWiseUserConverter>();
        builder.Services.AddScoped<DirectorConverter>();
        builder.Services.AddScoped<StarConverter>();



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

