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
      // Use the user's ID as the cartId if authenticated
      if (User.Identity.IsAuthenticated)
      {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
      }

      // For guest users, use the cartId stored in cookies
      return Request.Cookies["CartId"];
    }

    public async Task OnGetAsync()
    {
      string cartId = GetCartId();

      // Make sure the cartId is valid
      if (string.IsNullOrEmpty(cartId))
      {
        Cart = new CartDTO(); // Initialize an empty cart to avoid null reference
        return;
      }

      var response = await _httpClient.GetAsync($"api/cart/{cartId}");

      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();

        // Assign the deserialized cart to the Cart property
        Cart = JsonSerializer.Deserialize<CartDTO>(jsonResponse, new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true
        });
      }
      else
      {
        // Initialize an empty cart if the request fails
        Cart = new CartDTO();
      }
    }
  }
}
