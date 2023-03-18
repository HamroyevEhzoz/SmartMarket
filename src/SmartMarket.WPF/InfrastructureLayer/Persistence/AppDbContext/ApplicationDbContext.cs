using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartMarket.WPF.ApplicationLayer.Abstractions;
using SmartMarket.WPF.DomainLayer.Entities;
using SmartMarket.WPF.infrastructureLayer.Persistence.EntityTypeConfigurations;

namespace SmartMarket.WPF.infrastructureLayer.Persistence.AppDbContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = ConfigurationHelper.GetConfiguration();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
