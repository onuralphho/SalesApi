using Microsoft.EntityFrameworkCore;
using SalesProject.Entities;

namespace SalesProject.Context
{
    public class SalesDbContext:DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }
        public DbSet<Product> Product { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Order> Order { get; set; }

    }

}
