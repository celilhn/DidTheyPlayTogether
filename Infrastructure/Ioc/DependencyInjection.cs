//using Application.Interfaces;
//using Application.Logging;
//using Application.Mapping;
//using Application.Services;
using Application.Interfaces;
using Application.Logging;
using Application.Mapping;
using Application.Services;
using Application.Utilities;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.MovieDbServices;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFamousService, FamousService>();
            services.AddScoped<IFamousRepository, FamousRepository>();
            services.AddScoped<ISerieService, SerieService>();
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IPlayedFilmRepository, PlayedFilmRepository>();
            services.AddScoped<IMovieDbMovieService, MovieDbMovieService>();
            services.AddScoped<IMovieDbPeopleService, MovieDbPeopleService>();
            services.AddScoped<IMovieDbTvService, MovieDbTvService>();
            services.AddScoped<IHttpUtilities, HttpUtilities>();
            services.AddScoped<IPlayedFilmService, PlayedFilmService>();
            services.AddDbContext<DidTheyPlayTogetherDbContext>(options => options.UseSqlServer(
                   GetDbConnectionText(),
                   b => b.MigrationsAssembly(typeof(DidTheyPlayTogetherDbContext).Assembly.FullName)));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<ILoggerManager, LoggerManager>();
        }

        private static string GetDbConnectionText()
        {
            string connectionString = "Data Source=DESKTOP-OUS3O83;Initial Catalog=DIDTHEYPLAYTOGETHER;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //connectionString = string.Format(connectionString, Environment.GetEnvironmentVariable("FuntasyDbUser"), Environment.GetEnvironmentVariable("FuntasyDbPassword"));
            //Sunucu restartında ne olacağına emin olunmadığı için comment alındı
            return connectionString;
        }
    }
}
