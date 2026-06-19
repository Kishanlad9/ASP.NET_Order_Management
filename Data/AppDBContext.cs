using Microsoft.EntityFrameworkCore;
using Order_management.Models;

namespace Order_management.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
       
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
            modelBuilder.Entity<Products>(entity =>
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
