using aspnet_core.DTOs.Users;
using aspnet_core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userServices;

        public AuthController(UserService UserServices)
        {
            _userServices = UserServices;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUpdateUserDTO dto)
        {
            try
            {
                await _userServices.CreateUser(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var resp = await _userServices.GetAllUser();
                return Ok(new { Status = "Success", data = resp });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
