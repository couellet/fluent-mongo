using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FluentMongo
{
    public abstract class MongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}