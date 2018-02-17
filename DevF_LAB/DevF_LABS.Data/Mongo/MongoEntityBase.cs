using MongoDB.Bson.Serialization.Attributes;

namespace DevF_LABS.Data.Mongo
{
    public class MongoEntityBase
    {
        [BsonId]
        public string ID { get; set; }
    }
}
