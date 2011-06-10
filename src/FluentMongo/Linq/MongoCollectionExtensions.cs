using System;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace FluentMongo.Linq
{
    public static class MongoCollectionExtensions
    {
        public static IQueryable<T> AsQueryable<T>(this MongoCollection<T> collection)
        {
            return new MongoQuery<T>(new MongoQueryProvider(collection));
        }

        public static MongoCollection<T> UpdateSingleElement<T, TValue>(this MongoCollection<T> collection, T source, Expression<Func<T, TValue>> member, BsonValue newValue) where T : MongoEntity
        {
            var body = member.Body as MemberExpression;

            if (body == null)
                return collection;

            var query = Query.EQ("_id", source.Id);
            var update = Update.Set(body.Member.Name, newValue);

            //collection.Update(query, update);
            collection.FindAndModify(query, SortBy.Null, update);

            return collection;
        }
    }
}