using KhumaloCraft.Data;
using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCraft.Pages
{
    public class ContactModel : PageModel
    {   
        private readonly ApplicationDbContext _db;
        public List<Product> ProductList { get; set; } = new List<Product>();

        public ContactModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            ProductList = _db.Product.ToList();
        }
    }
}
