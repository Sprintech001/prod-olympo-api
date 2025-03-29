using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using olympo_webapi.Models;
using olympo_webapi.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olympo_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseDayController : ControllerBase
    {
        private readonly ConnectionContext _context;

        public ExerciseDayController(ConnectionContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}/exercises")]
        public async Task<ActionResult<IEnumerable<ExerciseDay>>> GetExercisesByUserId(int userId)
        {
            var userExercises = await _context.ExerciseDays
                .Where(ed => ed.UserId == userId)
                .ToListAsync();

            if (userExercises.Count == 0)
            {
                return NotFound($"No exercises found for user with ID {userId}.");
            }

            return Ok(userExercises);
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseDay>> CreateExerciseDay([FromBody] ExerciseDay exerciseDay)
        {
            _context.ExerciseDays.Add(exerciseDay);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Id = exerciseDay.Id,
                ExerciseId = exerciseDay.ExerciseId,
                DayOfWeek = exerciseDay.DayOfWeek,
                SessionId = exerciseDay.SessionId,
                UserId = exerciseDay.UserId
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseDay(int id, [FromBody] ExerciseDay exerciseDay)
        {
            if (id != exerciseDay.Id)
            {
                return BadRequest("ExerciseDay ID mismatch.");
            }

            _context.Entry(exerciseDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseDayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseDay(int id)
        {
            var exerciseDay = await _context.ExerciseDays.FindAsync(id);
            if (exerciseDay == null)
            {
                return NotFound();
            }

            _context.ExerciseDays.Remove(exerciseDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExerciseDayExists(int id)
        {
            return _context.ExerciseDays.Any(e => e.Id == id);
        }
    }
}
