using System.ComponentModel.DataAnnotations;

namespace KhumaloCraft.Models
{
  public class User
  {
    public int UserId { get; set; }
   
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    public string passwordHash { get; set; }
  }
}