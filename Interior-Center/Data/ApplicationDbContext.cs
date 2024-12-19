using Microsoft.EntityFrameworkCore;
using Interior_Center.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace Interior_Center.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Catalog> Catalog { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Reviews> Reviews { get; set; }

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
            var converter = new ValueConverter<List<int>, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), // Преобразование в JSON
                v => string.IsNullOrEmpty(v) ? new List<int>() : JsonSerializer.Deserialize<List<int>>(v, new JsonSerializerOptions())
            );

            modelBuilder.Entity<Users>()
                .Property(u => u.Cart)
                .HasConversion(converter); // Применяем конвертер

            modelBuilder.Entity<Reviews>()
                .HasNoKey();
        }
    }
}
