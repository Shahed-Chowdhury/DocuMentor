using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace aspnet_core.Models
{
    public class Role
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
