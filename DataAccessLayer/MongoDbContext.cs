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
            const string connectionUri = "mongodb+srv://Conor:1QthZTZLImj72wvD@soa-ca2.q4m6g5r.mongodb.net/?retryWrites=true&w=majority";
            var dbsettings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to Stable API version 1
            dbsettings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            var client = new MongoClient(dbsettings);



            //string connectionUri = Environment.GetEnvironmentVariable("connectionUrl");
            //var dbsettings = MongoClientSettings.FromConnectionString(connectionUri);
            //// Set the ServerApi field of the settings object to Stable API version 1
            //dbsettings.ServerApi = new ServerApi(ServerApiVersion.V1);


            //var client = new MongoClient(dbsettings);
            if (client != null)
                _database = client.GetDatabase("SOA-CA2");
        }

        public IMongoCollection<Book> Books => _database.GetCollection<Book>("Books");
        public IMongoCollection<Author> Authors => _database.GetCollection<Author>("Authors");
    }

}
