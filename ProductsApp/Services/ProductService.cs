using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;

namespace ProductsApi.Services
{
    public class ProductService : IProductService
    {

        private readonly SqlServerDbContext _sqlServerDbContext;
        public ProductService(SqlServerDbContext sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            await _sqlServerDbContext.Products.AddAsync(product);
            await _sqlServerDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(Product product)
        {
            _sqlServerDbContext.Products.Remove(product);
            await _sqlServerDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _sqlServerDbContext.Products.ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            _sqlServerDbContext.Products.Update(product);
            await _sqlServerDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _sqlServerDbContext.Products.FindAsync(id);
        }

        public async Task<Product?> FindProductByIdAsync(int id)
        {
           return await _sqlServerDbContext.FindAsync<Product>(id);
        }
    }
}