using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DbStoreContext : DbContext
    {
        public DbStoreContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
