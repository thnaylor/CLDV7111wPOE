using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages
{
  public class CheckoutModel : PageModel
  {
    public OrderDTO Order { get; set; }

    public void OnGet()
    {
      if (TempData["OrderDTO"] != null)
      {
        var orderJson = TempData["OrderDTO"].ToString();
        Order = JsonSerializer.Deserialize<OrderDTO>(orderJson, new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true
        });
      }
    }
  }
}
