using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Models;
using olympo_webapi.Infrastructure;

namespace olympo_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymController : ControllerBase
    {
        private readonly IGymRepository _gymRepository;

        public GymController(IGymRepository gymRepository)
        {
            _gymRepository = gymRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gym>>> GetAll()
        {
            var gyms = await _gymRepository.GetAllAsync();
            return Ok(gyms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gym>> GetById(int id)
        {
            var gym = await _gymRepository.GetByIdAsync(id);
            if (gym == null)
                return NotFound();

            return Ok(gym);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Gym gym)
        {
            await _gymRepository.AddAsync(gym);
            return CreatedAtAction(nameof(GetById), new { id = gym.Id }, gym);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Gym updatedGym)
        {
            var existingGym = await _gymRepository.GetByIdAsync(id);
            if (existingGym == null)
                return NotFound();

            updatedGym.Id = id;
            await _gymRepository.UpdateAsync(updatedGym);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var gym = await _gymRepository.GetByIdAsync(id);
            if (gym == null)
                return NotFound();

            await _gymRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
