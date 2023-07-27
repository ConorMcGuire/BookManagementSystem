using System;

namespace BookManagementSystem.Entities
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("genre")]
        public string Genre { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("authorId")]
        public string AuthorId { get; set; }

        [BsonElement("publishedDate")]
        public DateTime PublishedDate { get; set; }
    }


}
