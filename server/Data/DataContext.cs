using Microsoft.EntityFrameworkCore;
using QRMES.Entities;

namespace QRMES.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.RegistrationDate)
                .HasDefaultValueSql("getdate()");
        }
        public DbSet<Product> Products { get; set; }
    }
}
