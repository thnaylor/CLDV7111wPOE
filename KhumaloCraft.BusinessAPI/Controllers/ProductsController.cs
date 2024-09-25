using Microsoft.AspNetCore.Mvc;
using KhumaloCraft.Business.Services;
using KhumaloCraft.Shared.DTOs.ProductDTO;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDTO)
        {
            await _productService.AddProduct(productDTO);
            return Ok("Product added successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.ProductId) return BadRequest("Product ID mismatch");

            await _productService.UpdateProduct(productDTO);
            return Ok("Product updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok("Product deleted successfully");
        }
    }
}
