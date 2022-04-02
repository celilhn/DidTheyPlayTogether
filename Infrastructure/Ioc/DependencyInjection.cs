//using Application.Interfaces;
//using Application.Logging;
//using Application.Mapping;
//using Application.Services;
//using Application.Utilities;
using Application.Mapping;
using AutoMapper;
using Infrastructure.Context;
//using Domain.Interfaces;
//using Infrastructure.Context;
//using Infrastructure.Notifications;
//using Infrastructure.Repositories;
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
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IUserRepository, UserRepository>();
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
            //services.AddScoped<ILoggerManager, LoggerManager>();
        }

        private static string GetDbConnectionText()
        {
            string connectionString = "server=37.131.255.156; user=aeradmin; password=rXkT84YV; database=FUNTASY;";
            //connectionString = string.Format(connectionString, Environment.GetEnvironmentVariable("FuntasyDbUser"), Environment.GetEnvironmentVariable("FuntasyDbPassword"));
            //Sunucu restartında ne olacağına emin olunmadığı için comment alındı
            return connectionString;
        }
    }
}
