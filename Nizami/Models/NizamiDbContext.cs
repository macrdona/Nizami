using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
/*
* This class acts as an interface to pull data from the database
*/
namespace Nizami.Models
{
    public class NizamiDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public NizamiDbContext(DbContextOptions<NizamiDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
