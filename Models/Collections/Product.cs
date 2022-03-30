using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace kcms_challenge_dev_backend.Models.Collections
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductID { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("CategoryID")]
        public string CategoryID { get; set; }
    }
}
