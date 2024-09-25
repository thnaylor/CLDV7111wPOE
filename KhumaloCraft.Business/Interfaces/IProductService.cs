using KhumaloCraft.Data.Entities;

namespace KhumaloCraft.Business.Services;

public interface IProductService
{
  Task<List<Product>> GetAllProducts();
}
