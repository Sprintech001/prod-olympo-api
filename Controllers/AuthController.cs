using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Models;
using olympo_webapi.Services;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthController(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }


    // ----------------- JWT ----------------- // (Posterior implementaçãos)

    // private string GenerateJwtToken(User user)
    // {
    //     var claims = new[]
    //     {
    //         new Claim(JwtRegisteredClaimNames.Sub, user.Email),
    //         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //         new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
    //     };

    //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //     var token = new JwtSecurityToken(
    //         _configuration["Jwt:Issuer"],
    //         _configuration["Jwt:Issuer"],
    //         claims,
    //         expires: DateTime.Now.AddMinutes(30),
    //         signingCredentials: creds);

    //     return new JwtSecurityTokenHandler().WriteToken(token);
    // }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Email) || string.IsNullOrWhiteSpace(loginRequest.Password))
        {
            return BadRequest(new { Message = "Invalid login request" });
        }

        var user = await _userRepository.GetByEmailAsync(loginRequest.Email);
        Console.WriteLine("User" + user);

        if (user == null)
        {
            return Unauthorized(new { Message = "User is Null" });
        }

        var passwordVerificationResult = HashService.PasswordVerificationResult(user.Password, loginRequest.Password);

        if (passwordVerificationResult == PasswordVerificationResult.Success)
        {
            HttpContext.Session.SetString("UserId", user.Id.ToString());

            return Ok(new 
            { 
                Message = "Login successful", 
                User = new 
                {
                    user.Id,
                    user.Email,
                    user.Name,
                    user.Type
                } 
            });
        } 
        else
        {

            return Unauthorized(new { Message = "Invalid email or password" });
        }
    
        // switch (passwordVerificationResult)
        // {
        //     case PasswordVerificationResult.Success:
        //         // A senha está correta
        //         var token = GenerateJwtToken(user);
        //         return Ok(new { Message = "Login successful", Token = token });

        //     case PasswordVerificationResult.Failed:
        //         // A senha está incorreta
        //         return Unauthorized(new { Message = "Invalid email or password" });

        //     case PasswordVerificationResult.SuccessRehashNeeded:
        //         // O hash precisa ser refeito, re-hash a senha e salvar novamente (opcional)
        //         return Unauthorized(new { Message = "Password hash needs rehashing" });

        //     default:
        //         return Unauthorized(new { Message = "Invalid email or password" });
        // }
    }

    [AllowAnonymous]
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Ok(new { Message = "Logged out successfully" });
    }

}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
