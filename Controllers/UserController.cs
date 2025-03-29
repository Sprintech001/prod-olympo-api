﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Infrastructure;
using olympo_webapi.Models;
using olympo_webapi.Services;
using Microsoft.AspNetCore.Authorization;

namespace olympo_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IFileUploadService _fileUploadService;

        public UserController(IUserRepository userRepository, IExerciseRepository exerciseRepository, IFileUploadService fileUploadService)
        {
            _userRepository = userRepository;
            _exerciseRepository = exerciseRepository;
            _fileUploadService = fileUploadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = await _userRepository.GetAsync();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
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
                    Password = HashService.HashPassword(input.Password),
                };

                await _userRepository.AddAsync(user);

                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request. ==> " + ex);
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
                existingUser.Image = updatedUser.Image;
                existingUser.Password = updatedUser.Password;

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

    }
}