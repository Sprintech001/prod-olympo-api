using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Services;
using olympo_webapi.Models;

namespace olympo_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IFileUploadService _fileUploadService;

        public ExerciseController(IExerciseRepository exerciseRepository, ISessionRepository sessionRepository, IFileUploadService fileUploadService)
        {
            _exerciseRepository = exerciseRepository;
            _sessionRepository = sessionRepository;
            _fileUploadService = fileUploadService;
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

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                var filePath = await _fileUploadService.UploadFileAsync(file);
                return Ok(new { filePath });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex}");
                return StatusCode(500, "An error occurred while processing the request. ==> " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Exercise input)
        {
            try
            {
                if (input == null)
                {
                    return BadRequest("Dados do exercicio inválido.");
                }

                string? imagePath = null;
                if (input.Image != null)
                {
                    imagePath = await _fileUploadService.UploadFileAsync(input.Image);
                }

                string? videoPath = null;
                if (input.Video != null)
                {
                    videoPath = await _fileUploadService.UploadFileAsync(input.Video);
                }

                var exercise = new Exercise
                {
                    Name = input.Name,
                    Description = input.Description,
                    ImagePath = imagePath,
                    VideoPath = videoPath,
                };

                await _exerciseRepository.AddAsync(exercise);

                return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex}");
                return StatusCode(500, "An error occurred while processing the request. ==> " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] Exercise updatedExercise, [FromForm] IFormFile? image, [FromForm] IFormFile? video)
        {
            if (updatedExercise == null || id != updatedExercise.Id)
            {
                return BadRequest("Exercicio não encontrado.");
            }

            try
            {
                var existingExercise = await _exerciseRepository.GetByIdAsync(id);
                if (existingExercise == null)
                {
                    return NotFound("Exercicio não encontrado.");
                }

                existingExercise.Name = updatedExercise.Name;
                existingExercise.Description = updatedExercise.Description;

                if (image != null)
                {
                    existingExercise.ImagePath = await _fileUploadService.UploadFileAsync(image);
                }

                if (video != null)
                {
                    existingExercise.VideoPath = await _fileUploadService.UploadFileAsync(video);
                }

                await _exerciseRepository.UpdateAsync(existingExercise);
                return Ok("Exercício atualizado");
            }
            catch (Exception ex)
            {
                var errorMessage = $"Internal server error: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $" Inner exception: {ex.InnerException.Message}";
                }

                return StatusCode(500, errorMessage);
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