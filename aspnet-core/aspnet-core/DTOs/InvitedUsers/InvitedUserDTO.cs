namespace aspnet_core.DTOs.InvitedUsers
{
    public class InvitedUserDTO
    {
        public string? Id { get; set; }
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Message { get; set; }
    }
}
