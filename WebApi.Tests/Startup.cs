using Application.Utilities;
using Infrastructure.Ioc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

namespace WebApi.Tests
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup()
        {
            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Path.Combine(folderPath, "sharedsettings.json"), false, true)
                //.AddJsonFile(Path.Combine(folderPath, "appsettings.json"), false, true)
                .AddEnvironmentVariables()
                .Build();
            AppUtilities.AppUtilitiesConfigure(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            DependencyInjection.RegisterServices(services, configuration);
        }
    }
}
