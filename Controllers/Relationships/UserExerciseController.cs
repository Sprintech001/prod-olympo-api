using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using olympo_webapi.Models;
using olympo_webapi.Infrastructure;

namespace olympo_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserExerciseController : ControllerBase
    {
        private readonly IUserExerciseRepository _userExerciseRepository;
        private readonly ConnectionContext _context;

        public UserExerciseController(IUserExerciseRepository userExerciseRepository, ConnectionContext context)
        {
            _userExerciseRepository = userExerciseRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserExercise>>> GetAll()
        {
            var result = await _userExerciseRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<UserExercise>>> GetByUser(int userId)
        {
            var result = await _userExerciseRepository.GetByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpGet("exercise/{exerciseId}")]
        public async Task<ActionResult<IEnumerable<UserExercise>>> GetByExercise(int exerciseId)
        {
            var result = await _userExerciseRepository.GetByExerciseIdAsync(exerciseId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserExercise userExercise)
        {
            await _userExerciseRepository.AddAsync(userExercise);
            return Created("", userExercise);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int userId, [FromQuery] int exerciseId)
        {
            await _userExerciseRepository.DeleteAsync(userId, exerciseId);
            return NoContent();
        }

        [HttpGet("sessions")]
        public async Task<IActionResult> GetSessionsByUserAndExercise(int userId, int exerciseId)
        {
            var sessions = await _context.Sessions
                .Where(s => s.UserId == userId && s.ExerciseId == exerciseId)
                .Include(s => s.Exercise)
                .Include(s => s.User)
                .ToListAsync();

            if (sessions == null || sessions.Count == 0)
            {
                return NotFound();
            }

            return Ok(sessions);
        }
    }
}
