using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsModelController : ControllerBase
    {
        private readonly ICarsModelRepository _carsModelRepository;

        public CarsModelController(ICarsModelRepository carsModelRepository)
        {
            _carsModelRepository = carsModelRepository;
        }

        // Lấy tất cả CarModel
        [HttpGet]
        public async Task<ActionResult<List<CarModel>>> GetCarModels()
        {
            var models = await _carsModelRepository.GetAllCarModelsAsync();
            return Ok(models);
        }

        // Lấy CarModel theo Id
        [HttpGet("{id}")]
        public async Task<ActionResult<CarModel>> GetCarModelById(int id)
        {
            var model = await _carsModelRepository.GetCarModelByIdAsync(id);
            if (model == null) return NotFound();
            return Ok(model);
        }

        // Thêm CarModel mới
        [HttpPost]
        public async Task<IActionResult> AddCarModel([FromBody] CarModel model)
        {
            await _carsModelRepository.AddCarModelAsync(model);
            return CreatedAtAction(nameof(GetCarModelById), new { id = model.ModelId }, model);
        }

        // Cập nhật CarModel
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarModel(int id, [FromBody] CarModel model)
        {
            if (model == null || id != model.ModelId)
                return BadRequest(new { message = "Dữ liệu không hợp lệ" });

            var existingModel = await _carsModelRepository.GetCarModelByIdAsync(id);
            if (existingModel == null)
                return NotFound(new { message = "Model không tồn tại" });

            await _carsModelRepository.UpdateCarModelAsync(model);
            return NoContent();
        }

        // Xóa CarModel
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarModel(int id)
        {
            var existingModel = await _carsModelRepository.GetCarModelByIdAsync(id);
            if (existingModel == null)
                return NotFound(new { message = "Model không tồn tại" });

            await _carsModelRepository.RemoveCarModelAsync(id);
            return NoContent();
        }
    }
}


