using System.Text;
using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages.Admin.Products
{
  public class EditModel : PageModel
  {
    private readonly HttpClient _httpClient;
    private readonly ILogger<EditModel> _logger;

    public EditModel(HttpClient httpClient, ILogger<EditModel> logger)
    {
      _httpClient = httpClient;
      _logger = logger;
    }

    [BindProperty]
    public ProductDTO Product { get; set; }
    public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();

    public async Task<IActionResult> OnGetAsync(int id)
    {
      var response = await _httpClient.GetAsync($"http://localhost:5068/api/products/{id}");
      if (response.IsSuccessStatusCode)
      {
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Product = JsonSerializer.Deserialize<ProductDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
      }

      await LoadCategoriesAsync();

      if (Product == null)
      {
        return NotFound();
      }

      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        await LoadCategoriesAsync();

        foreach (var modelStateKey in ModelState.Keys)
        {
          var value = ModelState[modelStateKey];
          foreach (var error in value.Errors)
          {
            _logger.LogError($"ModelState error: {error.ErrorMessage}");
          }
        }
        return Page();
      }

      var jsonProduct = JsonSerializer.Serialize(Product);
      _logger.LogInformation($"Sending JSON to API: {jsonProduct}");
      var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

      var response = await _httpClient.PutAsync($"http://localhost:5068/api/products/{Product.ProductId}", content);

      if (response.IsSuccessStatusCode)
      {
        return RedirectToPage("/Admin/Products/Index");
      }

      _logger.LogError($"Failed to update category. Status code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
      ModelState.AddModelError(string.Empty, "Error updating product.");
      return Page();
    }

    private async Task LoadCategoriesAsync()
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
