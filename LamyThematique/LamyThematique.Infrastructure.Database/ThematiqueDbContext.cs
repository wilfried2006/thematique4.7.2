using System.Reflection;
using LamyThematique.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LamyThematique.Infrastructure.Database
{
    public class ThematiqueDbContext : DbContext
    { 
        public ThematiqueDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);  

        //    //optionsBuilder.uses

        //}
    }
}