using BookManagementSystem.DataAccessLayer;
using BookManagementSystem.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BookManagementSystem.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly MongoDbContext _context;

        public AuthorRepository(MongoDbContext context)
        {
            _context = context;
        }

        // Create
        public void AddAuthor(Author author)
        {
            _context.Authors.InsertOne(author);
        }

        //Read all
        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.Find(_ => true).ToList();
        }

        //Read 1
        public Author GetAuthorById(string id)
        {
            return _context.Authors.Find(author => author.Id == id).FirstOrDefault();
        }

        //Update
        public void UpdateAuthor(Author author)
        {
            _context.Authors.ReplaceOne(b => b.Id == author.Id, author);
        }

        //Delete
        public void DeleteAuthor(string id)
        {
            _context.Authors.DeleteOne(b => b.Id == id);
        }


    }
}
