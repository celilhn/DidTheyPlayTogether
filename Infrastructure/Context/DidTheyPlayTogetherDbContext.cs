using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DidTheyPlayTogetherDbContext : DbContext
    {
        public DidTheyPlayTogetherDbContext(DbContextOptions<DidTheyPlayTogetherDbContext> options) : base(options) { }
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<Famous> Famouses { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<PlayedFilm> PlayedFilms { get; set; }
        public DbSet<PlayedSerie> PlayedSeries { get; set; }
        public DbSet<Serie> Series { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
