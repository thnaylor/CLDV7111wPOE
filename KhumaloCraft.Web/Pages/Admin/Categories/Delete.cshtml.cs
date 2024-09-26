using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Web.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public int Id { get; set; }

        public IActionResult OnGet(int id)
        {
            Id = id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5068/api/categories/{Id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Admin/Categories/Index");
            }

            ModelState.AddModelError(string.Empty, "Error deleting category.");
            return Page();
        }
    }
}
