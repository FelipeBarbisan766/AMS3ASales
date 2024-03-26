using AMS3ASales.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace AMS3ASales.API.Context
{
    public class AplicationDataContext : DbContext
    {
        public AplicationDataContext(DbContextOptions<AplicationDataContext> options) : base(options) { }
        
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }


    }
}
