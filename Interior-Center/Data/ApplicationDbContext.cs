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
            var converter = new ValueConverter<List<string>?, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), // Преобразование в JSON
                v => string.IsNullOrEmpty(v) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(v, new JsonSerializerOptions())
            );

            modelBuilder.Entity<Users>()
                .Property(u => u.Cart)
                .HasConversion(converter); // Применяем конвертер
        }
    }
}
