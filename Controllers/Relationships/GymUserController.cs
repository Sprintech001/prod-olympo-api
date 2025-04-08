using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Models;
using olympo_webapi.Infrastructure;

namespace olympo_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymUserController : ControllerBase
    {
        private readonly IGymUserRepository _gymUserRepository;

        public GymUserController(IGymUserRepository gymUserRepository)
        {
            _gymUserRepository = gymUserRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymUser>>> GetAll()
        {
            var result = await _gymUserRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GymUser>>> GetByUser(int userId)
        {
            var result = await _gymUserRepository.GetByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpGet("gym/{gymId}")]
        public async Task<ActionResult<IEnumerable<GymUser>>> GetByGym(int gymId)
        {
            var result = await _gymUserRepository.GetByGymIdAsync(gymId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] GymUser gymUser)
        {
            await _gymUserRepository.AddAsync(gymUser);
            return Created("", gymUser);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int userId, [FromQuery] int gymId)
        {
            await _gymUserRepository.DeleteAsync(userId, gymId);
            return NoContent();
        }
    }
}
