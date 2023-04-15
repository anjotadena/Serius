using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DbStoreContext : DbContext
    {
        public DbStoreContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
