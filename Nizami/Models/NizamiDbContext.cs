using Microsoft.EntityFrameworkCore;

/*
 * This class acts as an interface to pull data from the database
 */
namespace Nizami.Models
{
    public class NizamiDbContext : DbContext
    {
        public NizamiDbContext(DbContextOptions<NizamiDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
