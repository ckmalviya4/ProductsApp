using ProductsApi.Data;

namespace ProductsApi.Services
{
    public interface IProductService
    {
        Task<Product?> FindProductByIdAsync(int id);

        Task<Product?> GetProductByIdAsync(int id);
        Task<List<Product>> GetAllProductsAsync();

        Task<bool> AddProductAsync(Product product0);
        Task<bool> UpdateProductAsync(Product product);

        Task<bool> DeleteProductAsync(Product product);
    }
}
