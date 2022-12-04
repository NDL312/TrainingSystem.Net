using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_CRUD.Models
{
    public class Skill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string SkillName { get; set; }

    }
}
