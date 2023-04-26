namespace aspnet_core.DTOs.InvitedUsers
{
    public class CreateUpdateInvitedUserDTO
    {
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Message { get; set; }
    }
}
