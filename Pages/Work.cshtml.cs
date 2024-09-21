using KhumaloCraft.Data;
using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Pages
{
    public class WorkModel : PageModel
    {   
        private readonly ApplicationDbContext _db;
        public List<Product> ProductList { get; set; } = new List<Product>();

        public WorkModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            ProductList = _db.Product.ToList();
        }
    }
}
