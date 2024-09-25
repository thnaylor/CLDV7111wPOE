using Microsoft.AspNetCore.Mvc;
using KhumaloCraft.Data.Entities;
using KhumaloCraft.Business.Services;

namespace KhumaloCraft.BusinessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            return Ok(products);
        }
    }
}
