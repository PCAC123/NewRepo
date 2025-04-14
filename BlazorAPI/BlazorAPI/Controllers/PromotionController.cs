using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionRepository _repository;

        public PromotionController(IPromotionRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Promotion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promotion>>> GetAll()
        {
            var promotions = await _repository.GetAllPromotionsAsync();
            return Ok(promotions);
        }

        // GET: api/Promotion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promotion>> GetById(int id)
        {
            var promo = await _repository.GetPromotionByIdAsync(id);
            if (promo == null)
                return NotFound();

            return Ok(promo);
        }

        // POST: api/Promotion
        [HttpPost]
        public async Task<ActionResult> Create(Promotion promotion)
        {
            await _repository.AddPromotionAsync(promotion);
            return CreatedAtAction(nameof(GetById), new { id = promotion.PromotionId }, promotion);
        }

        // PUT: api/Promotion/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Promotion promotion)
        {
            if (id != promotion.PromotionId)
                return BadRequest("ID không khớp");

            await _repository.UpdatePromotionAsync(promotion);
            return NoContent();
        }

        // DELETE: api/Promotion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.RemovePromotionAsync(id);
            return NoContent();
        }
    }
}
