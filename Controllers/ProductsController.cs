using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using Microsoft.Extensions.Logging;

namespace MyProject.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ApplicationDbContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                if (products == null || !products.Any())
                {
                    _logger.LogWarning("No products available.");
                    return NotFound(new { message = "Product not found." });
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while get products.");
                return StatusCode(500, new { message = "An error occurred while get products on the server." });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    _logger.LogWarning($"Product with ID {id} not found.");
                    return NotFound(new { message = "Product not found." });
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while get the product.");
                return StatusCode(500, new { message = "An error occurred get the product on the server." });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest(new { message = "Invalid product." });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Products.Add(product);
                 await
                  _context.SaveChangesAsync();

                    return Ok(new { message = $"Product {product.Name} added successfully!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the product.");
                return StatusCode(500, new { message = "An error occurred while adding the product." });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest(new { message = "Product ID does not match." });
            }

            try
            {
                var existingProduct = await _context.Products.FindAsync(id);
                if (existingProduct == null)
                {
                    return NotFound(new { message = "Product not found." });
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.ImageUrl = product.ImageUrl;
                existingProduct.Discount = product.Discount;
                existingProduct.IsNew = product.IsNew;

                _context.Products.Update(existingProduct);    

                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    _logger.LogInformation($"Product updated: {product.Name}");
                    return Ok(new { message = $"Ptoduct {product.Name} updated successfully!" });
                }
                else
                {
                    return StatusCode(500, new { message = "Failed to update the product." });
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "An error occurred while updating the product.");
                return StatusCode(500, new { message = "An error occurred on the server." });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return Ok(new { message = "Product not found, but request processed successfully." });
                }

                _context.Products.Remove(product);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    _logger.LogInformation($"Product deleted: {product.Name}");
                    return Ok(new { message = $"Product {product.Name} deleted successfully!" });
                }
                else
                {
                    return StatusCode(500, new { message = "Failed to delete the product." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the product.");
                return StatusCode(500, new { message = "An error occurred on the server." });
            }
        }
    }
}
