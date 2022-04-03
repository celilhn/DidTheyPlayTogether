
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace Infrastructure.Context
{
    public class DidTheyPlayTogetherDbContextFactory : IDesignTimeDbContextFactory<DidTheyPlayTogetherDbContext>
    {
        private IConfiguration configuration;

        public DidTheyPlayTogetherDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DidTheyPlayTogetherDbContext>();

            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile(Path.Combine(folderPath, "sharedsettings.json"), false, true)
                //.AddJsonFile(Path.Combine(folderPath, "appsettings.json"), false, true)
                .AddEnvironmentVariables()
                .Build();

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-OUS3O83;Initial Catalog=DIDTHEYPLAYTOGETHER;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return new DidTheyPlayTogetherDbContext(optionsBuilder.Options);
        }
    }
}
