using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using LamyThematique.Domain.Common;
using LamyThematique.Infrastructure.Database.Entities.Document;
using LamyThematique.Infrastructure.Database.Entities.User;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;

namespace LamyThematique.Infrastructure.Database
{
    public class ThematiqueDbContext : DbContext
    {
        public AppSettings AppSettings { get; set; }
        public string connectionString { get; set; }

        public ThematiqueDbContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["thematiqueConnectionString"].ConnectionString;
        }

        public ThematiqueDbContext(AppSettings appSettings, DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.AppSettings = appSettings;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Sujet> Sujets { get; set; }

        public DbSet<Theme> Themes { get; set; }

        public DbSet<SousTheme> SousThemes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var azureProvider = new AzureServiceTokenProvider();

            var connection = new SqlConnection()
            {
                ConnectionString = AppSettings != null ? AppSettings.DatabaseConnectionString : connectionString,
            };

            if (!"Development".Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), StringComparison.CurrentCultureIgnoreCase)
                && Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != null)
                connection.AccessToken = azureProvider.GetAccessTokenAsync("https://database.windows.net/").Result;

            optionsBuilder.UseSqlServer(connection);
        }
    }
}