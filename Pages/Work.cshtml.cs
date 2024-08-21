using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Pages
{
    public class WorkModel : PageModel
    {
        private readonly ILogger<WorkModel> _logger;

        public WorkModel(ILogger<WorkModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
