using Microsoft.EntityFrameworkCore;
using Models.Domain;

namespace Data.Context
{
    public class VegaDbContext: DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) :base (options)
        {

        }

        public DbSet<Feature> Features { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Make> Makes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feature>().ToTable("Feature");
            modelBuilder.Entity<Model>().ToTable("Model");
            modelBuilder.Entity<Make>().ToTable("Make");
        }
    }
}
