using System.Collections.Generic;
using System;

namespace BookManagementSystem.Entities
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Author
    {
        [BsonId]  
        [BsonRepresentation(BsonType.ObjectId)] //MonngoDb ID
        public string Id { get; set; }

        [BsonElement("name")]  
        public string Name { get; set; }

        [BsonElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [BsonElement("bio")]
        public string Bio { get; set; }
    }


}
