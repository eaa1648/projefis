using Microsoft.AspNetCore.Mvc;
using projefis.Models;
using projefis.Services;
using System.Threading.Tasks;

namespace projefis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthenticationController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.LoginUser(loginDto);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _userService.GenerateJwtToken(user); // Bu satırı kontrol edin
            return Ok(new { Token = token });
        }
    }
}
