using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApiDEMO.Repositories
{
    class MongoDbItemsRepository : IItemsRepository
    {
        private const string dataBaseName = "catalog";

        private const string collectionName = "items";

        private readonly IMongoCollection<Item> itemsCollection;

        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(dataBaseName);
            this.itemsCollection = database.GetCollection<Item>(collectionName);
        }
        
        public IEnumerable<Item> GetItems()
        {
            return itemsCollection.Find(
                new BsonDocument()
            ).ToList();
        }

        public Item GetItem(Guid id)
        {
            // Need a filter definition builder.
            var filter = filterBuilder.Eq(item => item.Id, id);
            return itemsCollection.Find(filter).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            itemsCollection.ReplaceOne(filter, item);
        }

        public void DeleteItem(Guid id)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, id);
            itemsCollection.DeleteOne(filter);
        }
    }
}