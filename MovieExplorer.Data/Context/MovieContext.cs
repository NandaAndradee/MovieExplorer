using Microsoft.EntityFrameworkCore;
using MovieExplorer.Data.Mappings;
using MovieExplorer.Domain.Models;

namespace MovieExplorer.Data.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } = null!;

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
