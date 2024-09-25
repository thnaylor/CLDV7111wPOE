namespace KhumaloCraft.Data.Entities
{
  public class Order
  {
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.Now;

    public string UserId { get; set; }

    public User User { get; set; }
  }
}