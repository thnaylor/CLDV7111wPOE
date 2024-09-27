using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages.Admin.Products
{
  public class IndexModel : PageModel
  {
    private readonly HttpClient _httpClient;

    public IndexModel(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();

    public async Task OnGetAsync()
    {
      var response = await _httpClient.GetAsync("http://localhost:5068/api/products");
      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Products = JsonSerializer.Deserialize<List<ProductDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
      }
    }
  }
}
