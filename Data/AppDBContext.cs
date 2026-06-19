using Microsoft.EntityFrameworkCore;
using Order_management.Models;

namespace Order_management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.isDeleted)
                      .HasDefaultValue(false);

                entity.HasQueryFilter(c => !c.isDeleted);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

                entity.HasQueryFilter(c => !c.IsDeleted);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
