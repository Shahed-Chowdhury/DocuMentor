using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace aspnet_core.Models
{
    public class InvitedUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Email { get; set; } = null!;
        [BsonRepresentation(BsonType.ObjectId)]
        public string Role { get; set; } = null!;
        public string? Message { get; set; }
    }
}
