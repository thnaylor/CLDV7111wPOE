using System.ComponentModel.DataAnnotations;

namespace KhumaloCraft.Models
{
  public class Category
  {
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(50)]
    public string CategoryName { get; set; }
  }
}