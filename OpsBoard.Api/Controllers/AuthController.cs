using Microsoft.AspNetCore.Mvc;
using OpsBoard.Api.DTOs;
using OpsBoard.Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace OpsBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var success = await _authManager.RegisterAsync(dto);

            if (!success)
                return BadRequest("Email already exists.");

            return Ok(new { message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            var result = await _authManager.LoginAsync(dto);

            if (result == null)
                return Unauthorized("Invalid email or password.");

            return Ok(result);
        }
    }
}