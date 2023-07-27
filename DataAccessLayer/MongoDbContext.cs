using BookManagementSystem.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace BookManagementSystem.DataAccessLayer
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDbContext(IOptions<MongoDBSettings> settings)
        {
            string connectionUri = Environment.GetEnvironmentVariable("connectionUrl");
            var dbsettings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to Stable API version 1
            dbsettings.ServerApi = new ServerApi(ServerApiVersion.V1);


            var client = new MongoClient(dbsettings);
            if (client != null)
                _database = client.GetDatabase(Environment.GetEnvironmentVariable("dbName"));
        }

        public IMongoCollection<Book> Books => _database.GetCollection<Book>("Books");
        public IMongoCollection<Author> Authors => _database.GetCollection<Author>("Authors");
    }

}
