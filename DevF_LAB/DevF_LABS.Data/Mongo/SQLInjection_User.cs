using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace DevF_LABS.Data.Mongo
{
    public class SQLInjection_User
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public int ID { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("usersurname")]
        public string Usersurname { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
    }
}
