using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projefis.Models;
using projefis.Services;

namespace projefis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminOnly")] // Sadece admin kullanıcılar erişebilir
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody] RegisterDto registerDto)
        {
            var result = await _adminService.RegisterUser(registerDto);
            if (result)
                return Ok("User added successfully");
            else
                return BadRequest("User already exists");
        }

        [HttpDelete("delete-user/{userName}")]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            var user = await _adminService.GetUserByUserName(userName);
            if (user != null)
            {
                _adminService.DeleteUser(user);
                await _adminService.SaveChangesAsync();
                return Ok("User deleted successfully");
            }
            return NotFound("User not found");
        }
    }
}
