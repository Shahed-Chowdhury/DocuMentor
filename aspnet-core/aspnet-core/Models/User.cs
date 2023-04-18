using aspnet_core.DTOs.Roles;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace aspnet_core.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        [RegularExpression(@"^(?:(?:\+|00)88|01)?\d{11}$", ErrorMessage = "Number should be bangladeshi")]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Role { get; set; } = null!;
        public List<Role> Roles { get; set; }

    }
}
