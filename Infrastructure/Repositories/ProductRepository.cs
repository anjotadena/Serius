using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbStoreContext _context;

        public ProductRepository(DbStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Type)
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Type)
                .Include(p => p.Brand)
                .ToListAsync();
        }

        public Task<IReadOnlyList<Product>> GetProductBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Core.Entities.Type>> GetProductTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
