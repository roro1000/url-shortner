using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Domain
{
    public class TeenyURLContext : DbContext
    {
        public TeenyURLContext(DbContextOptions<TeenyURLContext> options) : base(options)
        {
        }

        public DbSet<URL> URL { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<URL>().ToTable("URL");
        }
    }
}
