using KhumaloCraft.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;


namespace KhumaloCraft.Web.Pages.Admin.Categories
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
		public CategoryDTO Category { get; set; }

		public async Task<IActionResult> OnGetAsync(int id)
		{
			var response = await _httpClient.GetAsync($"http://localhost:5068/api/categories/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonResponse = await response.Content.ReadAsStringAsync();
				Category = JsonSerializer.Deserialize<CategoryDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			}

			if (Category == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var jsonCategory = JsonSerializer.Serialize(Category);
			_logger.LogInformation($"Sending JSON to API: {jsonCategory}");
			var content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");

			var response = await _httpClient.PutAsync($"http://localhost:5068/api/categories/{Category.CategoryId}", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToPage("/Admin/Categories/Index");
			}

			_logger.LogError($"Failed to update category. Status code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
			ModelState.AddModelError(string.Empty, "Error updating category.");
			return Page();
		}
	}
}
