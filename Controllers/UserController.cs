using Microsoft.AspNetCore.Mvc;
using projefis.Models;
using projefis.Services;
using System.Threading.Tasks;

namespace projefis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _userService.RegisterUser(registerDto);
            if (result)
                return Ok("Kullanıcı başarıyla kaydedildi.");
            return BadRequest("Kullanıcı adı zaten mevcut.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.LoginUser(loginDto);
            if (user != null)
                return Ok("Giriş başarılı.");
            return Unauthorized("Kullanıcı adı veya şifre yanlış.");
        }
    }
}
