using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsRepository _repository;

        public OrderDetailsController(IOrderDetailsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetAll()
        {
            var details = await _repository.GetAllDetailsAsync();
            return Ok(details);
        }

        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetByOrderId(int orderId)
        {
            var details = await _repository.GetByOrderIdAsync(orderId);
            return Ok(details);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OrderDetail detail)
        {
            await _repository.AddDetailAsync(detail);
            return Ok(detail);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] OrderDetail detail)
        {
            if (id != detail.OrderDetailId)
                return BadRequest("ID không khớp");

            await _repository.UpdateDetailAsync(detail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.RemoveDetailAsync(id);
            return NoContent();
        }
    }
}
