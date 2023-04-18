using System.ComponentModel.DataAnnotations;

namespace aspnet_core.DTOs.Users
{
    public class CreateUpdateUserDTO
    {
        [Required]
        public string? UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        [RegularExpression(@"^(?:(?:\+|00)88|01)?\d{11}$", ErrorMessage = "Number should be bangladeshi")]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; } = null!;
    }
}
