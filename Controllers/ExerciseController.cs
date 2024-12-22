using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Models;
using System.Xml.Linq;

namespace olympo_webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExerciseController : ControllerBase
	{
		private readonly IExerciseRepository _exerciseRepository;

		public ExerciseController(IExerciseRepository exerciseRepository)
		{
			_exerciseRepository = exerciseRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Exercise>>> Get()
		{
			var exercises = await _exerciseRepository.GetAsync();

			if (exercises == null || exercises.Count == 0)
			{
				return NotFound("No exercises found.");
			}

			return Ok(exercises);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Exercise>> GetById(int id)
		{
			var exercise = await _exerciseRepository.GetByIdAsync(id);

			if (exercise == null)
			{
				return NotFound($"Exercise with ID {id} not found.");
			}

			return Ok(exercise);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Exercise exercise)
		{
			if (exercise == null)
			{
				return BadRequest("Exercise data is required.");
			}

			await _exerciseRepository.AddAsync(exercise);

			return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Exercise updatedExercise)
		{
			if (updatedExercise == null || id != updatedExercise.Id)
			{
				return BadRequest("Invalid exercise data or mismatched ID.");
			}

			try
			{
				await _exerciseRepository.UpdateAsync(updatedExercise);
				return Ok("Exercicio atualizado");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var exercise = await _exerciseRepository.GetByIdAsync(id);
			if (exercise == null)
			{
				return NotFound($"Exercise with ID {id} not found.");
			}

			await _exerciseRepository.DeleteAsync(id);

			return NoContent();
		}
	}
}
