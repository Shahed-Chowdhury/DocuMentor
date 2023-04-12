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
        private readonly MongoDBService _mongoDBService;

        public AuthController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUpdateUserDTO dto)
        {
            try
            {
                await _mongoDBService.CreateUser(dto);
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
                var resp = await _mongoDBService.GetAllUser();
                return Ok(new { Status = "Success", data = resp });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
