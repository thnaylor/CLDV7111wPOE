using KhumaloCraft.Data.Entities;

namespace KhumaloCraft.Data.Repositories.Interfaces;

public interface IProductRepository
{
  Task<List<Product>> GetAllProductsAsync();
  Task<Product?> GetProductByIdAsync(int productId);
  Task AddProductAsync(Product product);
  Task UpdateProductAsync(Product product);
  Task DeleteProductAsync(Product product);
  Task SaveChangesAsync();
}
