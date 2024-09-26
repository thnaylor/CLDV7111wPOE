using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages.Admin.Categories
{
  public class IndexModel : PageModel
  {
    private readonly HttpClient _httpClient;

    public IndexModel(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();

    public async Task OnGetAsync()
    {
      var response = await _httpClient.GetAsync("http://localhost:5068/api/categories");
      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Categories = JsonSerializer.Deserialize<List<CategoryDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
      }
    }
  }
}
