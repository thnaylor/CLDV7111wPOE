namespace KhumaloCraft.Models
{
  public class Order
  {
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.Now;

    public int UserId { get; set; }

    public User User { get; set; }
  }
}