using System.Text;
using System.Text.Json;
using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages.Admin.Categories
{
  public class CreateModel : PageModel
  {
    private readonly HttpClient _httpClient;

    public CreateModel(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    [BindProperty]
    public CategoryDTO Category { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var jsonCategory = JsonSerializer.Serialize(Category);
      var content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync("http://localhost:5068/api/categories", content);

      if (response.IsSuccessStatusCode)
      {
        return RedirectToPage("/Admin/Categories/Index");
      }

      ModelState.AddModelError(string.Empty, "Error creating category.");
      return Page();
    }
  }
}
