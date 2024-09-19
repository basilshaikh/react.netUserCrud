using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace userApplication.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("email")] 
        public string Email { get; set; } = string.Empty;

        [BsonElement("age")] 
        public string Age { get; set; } = string.Empty;

        [BsonElement("gender")]
        public string Gender { get; set; } = string.Empty;

        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;

        [BsonElement("isMarried")]
        public bool IsMarried { get; set; }
    }
}
