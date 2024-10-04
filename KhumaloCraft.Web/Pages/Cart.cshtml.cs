using System.Security.Claims;
using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages
{
  public class CartModel : PageModel
  {
    private readonly HttpClient _httpClient;
    public CartDTO Cart { get; set; } = new CartDTO(); // Initialize CartDTO

    public CartModel(IHttpClientFactory httpClientFactory)
    {
      _httpClient = httpClientFactory.CreateClient("BusinessAPI");
    }

    public string GetCartId()
    {
      if (User.Identity.IsAuthenticated)
      {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
      }

      return Request.Cookies["CartId"];
    }

    public async Task OnGetAsync()
    {
      string cartId = GetCartId();

      if (string.IsNullOrEmpty(cartId))
      {
        Cart = new CartDTO();
        return;
      }

      var response = await _httpClient.GetAsync($"api/cart/{cartId}");

      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();

        Cart = JsonSerializer.Deserialize<CartDTO>(jsonResponse, new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true
        });
      }
      else
      {
        Cart = new CartDTO();
      }
    }
  }
}
