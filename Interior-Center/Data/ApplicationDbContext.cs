using Microsoft.EntityFrameworkCore;
using Interior_Center.Models;



namespace Interior_Center.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Catalog> Catalog { get; set; }

        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FightClub1;Username=postgres;Password=123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
 }
