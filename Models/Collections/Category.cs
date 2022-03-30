using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace kcms_challenge_dev_backend.Models.Collections
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
