using System.Security.Claims;
using System.Text;
using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Pages.Work
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;
    private readonly HttpClient _httpClient;
    public List<ProductDTO> ProductList { get; set; } = new List<ProductDTO>();

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
    {
      _logger = logger;
      _httpClient = httpClientFactory.CreateClient("BusinessAPI");
    }

    public async Task OnGetAsync()
    {
      var response = await _httpClient.GetAsync("api/products");

      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        ProductList = JsonSerializer.Deserialize<List<ProductDTO>>(jsonResponse, new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true
        }) ?? new List<ProductDTO>();
      }
      else
      {
        _logger.LogError("Error fetching products from the API");
      }
    }

    public async Task<IActionResult> OnPostAddToCartAsync(int productId, string productName, decimal price)
    {
      string cartId = GetOrCreateCartId(); // Generate or retrieve the cartId

      var cartItem = new CartItemDTO
      {
        ProductId = productId,
        ProductName = productName,
        Price = price,
        Quantity = 1,
        CartId = cartId
      };

      var jsonContent = new StringContent(JsonSerializer.Serialize(cartItem), Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync($"api/cart/add?cartId={cartId}", jsonContent);

      if (response.IsSuccessStatusCode)
      {
        return RedirectToPage("/Cart"); // Redirect to Cart page after adding item
      }

      return Page(); // Reload current page if adding to cart fails
    }

    public string GetOrCreateCartId()
    {
      // Use the user's ID as the cartId if authenticated
      if (User.Identity.IsAuthenticated)
      {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
      }

      // For guest users, use cookie-based cartId
      if (Request.Cookies.ContainsKey("CartId"))
      {
        return Request.Cookies["CartId"];
      }

      // If no cartId exists, generate a new one and store it in cookies
      string cartId = Guid.NewGuid().ToString();
      Response.Cookies.Append("CartId", cartId, new CookieOptions
      {
        Expires = DateTimeOffset.UtcNow.AddDays(30),  // Expires in 30 days
        HttpOnly = true,                              // HttpOnly prevents JavaScript access
        IsEssential = true                            // GDPR compliance
      });

      return cartId;
    }
  }
}
