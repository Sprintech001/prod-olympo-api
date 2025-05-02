using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Infrastructure;
using olympo_webapi.Models;
using olympo_webapi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace olympo_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IFileUploadService _fileUploadService;
        private readonly ApplicationDbContext _context;

        public UserController(IUserRepository userRepository, IExerciseRepository exerciseRepository, IFileUploadService fileUploadService, ApplicationDbContext context)
        {
            _userRepository = userRepository;
            _exerciseRepository = exerciseRepository;
            _fileUploadService = fileUploadService;
            _context = context;
        }

        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _context.Users
                    .Select(u => new
                    {
                        u.Id,
                        u.Name,
                        u.Email,
                        u.CPF,
                        u.Phone,
                        u.Type,
                        u.BirthDate,
                        u.ImagePath,
                        Identity = _context.Users
                            .Where(iu => iu.Id == u.Id)
                            .Select(iu => new
                            {
                                iu.Id,
                                iu.Email
                            })
                            .FirstOrDefault()
                    })
                    .ToListAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno no servidor.", details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok(user);
        }

        [HttpGet("type")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserType([FromQuery] int type)
        {
            var users = await _userRepository.GetAsync();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            if (type == 1)
            {
                users = users.Where(u => (int)u.Type == 1).ToList();
            }
            else if (type == 2)
            {
                users = users.Where(u => (int)u.Type == 2).ToList();
            }
            else if (type == 3)
            {
                users = users.Where(u => (int)u.Type == 3).ToList();
            }
            else
            {
                return BadRequest("Invalid user type.");
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User input)
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

                var user = new User
                {
                    CPF = input.CPF,
                    Name = input.Name,
                    Email = input.Email,
                    ImagePath = imagePath,
                    Type = input.Type,
                };

                await _userRepository.AddAsync(user);

                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request. ==> " + ex);
            }
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User updatedUser)
        {
            if (updatedUser == null || id != updatedUser.Id)
            {
                return BadRequest("Dados de usuário inválidos ou ID incompatível.");
            }

            try
            {
                var existingUser = await _userRepository.GetByIdAsync(id);
                if (existingUser == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }

                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
                existingUser.Phone = updatedUser.Phone;
                existingUser.CPF = updatedUser.CPF;
                existingUser.BirthDate = updatedUser.BirthDate;
                existingUser.Image = updatedUser.Image;


                await _userRepository.UpdateAsync(existingUser);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            await _userRepository.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetLoggedUser()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                    return Unauthorized("Usuário não autenticado.");

                var applicationUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

                if (applicationUser == null)
                    return NotFound("Usuário não encontrado.");

                return Ok(applicationUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno no servidor.", details = ex.Message });
            }
        }

        [HttpPut("me")]
        [Authorize]
        public async Task<IActionResult> UpdateLoggedUser([FromForm] User updatedUser, IFormFile? image)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                    return Unauthorized("Usuário não autenticado.");

                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
                if (existingUser == null)
                    return NotFound("Usuário não encontrado.");

                existingUser.Name = updatedUser.Name ?? existingUser.Name;
                existingUser.Email = updatedUser.Email ?? existingUser.Email;
                existingUser.CPF = updatedUser.CPF ?? existingUser.CPF;
                existingUser.Phone = updatedUser.Phone ?? existingUser.Phone;
                existingUser.BirthDate = updatedUser.BirthDate ?? existingUser.BirthDate;

                if (image != null)
                {
                    var fileUploadService = new FileUploadService();
                    var imagePath = await fileUploadService.UploadFileAsync(image);
                    if (imagePath != null)
                    {
                        existingUser.ImagePath = $"/Storage/{imagePath}";
                    }
                }

                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();

                return Ok("Informações atualizadas com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno no servidor.", details = ex.Message });
            }
        }


        // ----------------- TIMESTAMP OF SERVER ----------------- //

        // This endpoint returns the current UTC date and time of the server
        // The objetcive is return the date for exercise day.

        [HttpGet("now")]
        [Route("now")]
        public IActionResult GetCurrentDate()
        {
            var zona = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"); // Windows
            var agora = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zona);

            return Ok(new {
                date = agora.ToString("yyyy-MM-dd"),
                time = agora.ToString("HH:mm:ss"),
                dayOfWeek = agora.DayOfWeek.ToString(),
                timeZone = zona.DisplayName,
                timeZoneOffset = "-03:00:00"
            });
        }

    }
}