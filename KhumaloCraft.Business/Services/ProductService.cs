using Microsoft.EntityFrameworkCore;
using KhumaloCraft.Data.Data;
using KhumaloCraft.Data.Entities;

namespace KhumaloCraft.Business.Services;

public class ProductService : IProductService
{
  private readonly ApplicationDbContext _dbContext;

  public ProductService(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<List<Product>> GetAllProducts()
  {
    // Fetch data from the Products table in the database
    var products = await _dbContext.Products.ToListAsync();
    return products;
  }
}
