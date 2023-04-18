using aspnet_core.DTOs.Roles;

namespace aspnet_core.DTOs.Users
{
    public class UserDTO
    {
        public string? Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; } = null!;
        public List<RoleDTO> Roles { get; set; } = null!;
    }
}
