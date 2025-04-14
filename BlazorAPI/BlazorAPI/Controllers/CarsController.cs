using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsRepository _carsRepository;

        public CarsController(ICarsRepository productRepository)
        {
            _carsRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetProducts()
        {
            var products = await _carsRepository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetProductById(int id)
        {
            var product = await _carsRepository.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Car product)
        {
            await _carsRepository.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.CarId }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Car product)
        {
            if (product == null || id != product.CarId)
                return BadRequest(new { message = "Dữ liệu không hợp lệ" });

            var existingProduct = await _carsRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
                return NotFound(new { message = "Sản phẩm không tồn tại" });

            await _carsRepository.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _carsRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
                return NotFound(new { message = "Sản phẩm không tồn tại" });

            await _carsRepository.RemoveProductAsync(id);
            return NoContent();
        }
    }
}
