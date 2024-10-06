using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages.Admin.Orders
{
  public class IndexModel : PageModel
  {
    private readonly HttpClient _httpClient;
    public List<OrderDisplayDTO> Orders { get; set; } = new List<OrderDisplayDTO>();  // Change to a list of orders

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
      _httpClient = httpClientFactory.CreateClient("BusinessAPI");
    }

    public async Task OnGetAsync()
    {
      var response = await _httpClient.GetAsync($"api/orders");

      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();

        Orders = JsonSerializer.Deserialize<List<OrderDisplayDTO>>(jsonResponse, new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true
        });
      }
      else
      {
        Orders = new List<OrderDisplayDTO>();  // Initialize empty list if there's an error
      }
    }
  }
}
