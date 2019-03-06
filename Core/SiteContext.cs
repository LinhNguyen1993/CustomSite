using CustomSite.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomSite.Core
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}