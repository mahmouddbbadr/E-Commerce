using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.IRepository;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class ProductRepository(StoreContext context) : IProductRepository
    {
        public async Task<List<ProductBrand>> GetProductBrandsAsync()
        {
            return await context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products
                .Include(p=> p.ProductType)
                .Include(p=> p.ProductBrand)
                .FirstOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .ToListAsync();

        }

        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            return await context.ProductTypes.ToListAsync();
        }
    }
}
