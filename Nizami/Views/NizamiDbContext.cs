using Microsoft.EntityFrameworkCore;
using Nizami.Models;

namespace Nizami.Views
{
	public class NizamiDbContext : DbContext
	{
        public NizamiDbContext(DbContextOptions<NizamiDbContext> options) : base(options){ }

        public DbSet<Product> Products { get; set; }
    }
}
