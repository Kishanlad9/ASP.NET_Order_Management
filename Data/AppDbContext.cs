using Microsoft.EntityFrameworkCore;
using Order_management.Models;

namespace Order_management.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }

    }
}
