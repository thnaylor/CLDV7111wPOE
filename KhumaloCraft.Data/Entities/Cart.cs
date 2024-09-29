namespace KhumaloCraft.Data.Entities;

public class Cart
{
  public string CartId { get; set; } = Guid.NewGuid().ToString();
  public List<CartItem> Items { get; set; } = new List<CartItem>();
  public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);
  public DateTime LastUpdatedAt { get; set; } // New field to track last update time
}

