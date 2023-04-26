using aspnet_core.DTOs.InvitedUsers;
using aspnet_core.DTOs.Roles;
using aspnet_core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitedUserController : ControllerBase
    {
        private readonly InvitedUserServices _invitedUserservices;

        public InvitedUserController(InvitedUserServices services)
        {
            _invitedUserservices = services;
        }

        [HttpPost]
        public async Task<IActionResult> SendInvitation(CreateUpdateInvitedUserDTO dto)
        {
            try
            {
                await _invitedUserservices.AddInviteUser(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
