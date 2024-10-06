using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages
{
  public class CartModel : PageModel
  {
    private readonly ILogger<CartModel> _logger;
    private readonly HttpClient _httpClient;
    public CartDTO Cart { get; set; } = new CartDTO();

    public CartModel(ILogger<CartModel> logger, IHttpClientFactory httpClientFactory)
    {
      _logger = logger;
      _httpClient = httpClientFactory.CreateClient("BusinessAPI");
    }

    public string GetCartId()
    {
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

    public async Task<IActionResult> OnPostCheckoutCartAsync(string cartId)
    {
      var response = await _httpClient.GetAsync($"api/cart/{cartId}");

      if (!response.IsSuccessStatusCode)
      {
        return Page();
      }

      var jsonResponse = await response.Content.ReadAsStringAsync();
      Cart = JsonSerializer.Deserialize<CartDTO>(jsonResponse, new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      });

      if (Cart == null || !Cart.Items.Any())
      {
        return Page();
      }

      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

      var orderDTO = new OrderDTO
      {
        UserId = userId,
        Items = Cart.Items.Select(cartItem => new OrderItemDTO
        {
          ProductId = cartItem.ProductId,
          ProductName = cartItem.ProductName,
          Price = cartItem.Price,
          Quantity = cartItem.Quantity
        }).ToList()
      };

      var orderContent = new StringContent(JsonSerializer.Serialize(orderDTO), Encoding.UTF8, "application/json");

      // Post the order to the API
      var orderResponse = await _httpClient.PostAsync("api/orders/create", orderContent);

      if (!orderResponse.IsSuccessStatusCode)
      {
        return Page();
      }

      /*       var clearCartResponse = await _httpClient.DeleteAsync($"api/cart/{cartId}");
            if (!clearCartResponse.IsSuccessStatusCode)
            {
              return Page();
            } */

      TempData["OrderDTO"] = JsonSerializer.Serialize(orderDTO);

      return RedirectToPage("/Checkout");
    }
  }
}
