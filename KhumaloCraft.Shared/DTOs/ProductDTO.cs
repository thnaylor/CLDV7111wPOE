namespace KhumaloCraft.Shared.DTOs;

public class ProductDTO
{
  public int ProductId { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
  public string Description { get; set; }
  public string ImageSrc { get; set; }
  public int CategoryId { get; set; }
  public string? CategoryName { get; set; }
}
