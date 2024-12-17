using Microsoft.EntityFrameworkCore;
using Interior_Center.Models;


namespace Interior_Center.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Catalog> Catalog { get; set; }

        public DbSet<Users> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Interior;Username=postgres;Password=123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
