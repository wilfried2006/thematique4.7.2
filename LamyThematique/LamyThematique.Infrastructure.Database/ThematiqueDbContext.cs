using System.IO;
using System.Reflection;
using LamyThematique.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LamyThematique.Infrastructure.Database
{
    public class ThematiqueDbContext : DbContext
    {
        public ThematiqueDbContext() { }

        public ThematiqueDbContext(DbContextOptions<ThematiqueDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
              if (!optionsBuilder.IsConfigured)
              {
                  IConfigurationRoot configuration = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json")
                      .Build();

                  var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
                  optionsBuilder.UseSqlServer(connectionString);
              }
          }*/
    }
}