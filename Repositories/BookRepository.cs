using BookManagementSystem.DataAccessLayer;
using BookManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoDbContext _context;

        public BookRepository(MongoDbContext context)
        {
            _context = context;
        }

        // Create
        public void AddBook(Book book)
        {
            _context.Books.InsertOne(book);
        }

        //Read all
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.Find(_ => true).ToList();
        }

        //Read 1
        public Book GetBookById(string id)
        {
            return _context.Books.Find(book => book.Id == id).FirstOrDefault();
        }

        //Update
        public void UpdateBook(Book book)
        {
            _context.Books.ReplaceOne(b => b.Id == book.Id, book);
        }

        //Delete
        public void DeleteBook(string id)
        {
            _context.Books.DeleteOne(b => b.Id == id);
        }





        //private readonly DatabaseContext _context;

        //public BookRepository(DatabaseContext context)
        //{
        //    _context = context;
        //}

        //public IEnumerable<Book> GetAllBooks()
        //{
        //    return _context.Books
        //                   .Include(b => b.Author)  // This gets the author of each book using the author id
        //                   .ToList();
        //}

        //public Book GetBookById(int id)
        //{
        //    return _context.Books.FirstOrDefault(b => b.BookId == id);
        //}

        //public void AddBook(Book book)
        //{
        //    if (book == null)
        //        throw new ArgumentNullException(nameof(book));

        //    _context.Books.Add(book);
        //    _context.SaveChanges();
        //}

        //public void UpdateBook(Book book)
        //{
        //    if (book == null)
        //        throw new ArgumentNullException(nameof(book));

        //    var existingBook = _context.Books.Find(book.BookId);
        //    if (existingBook == null)
        //        throw new InvalidOperationException("Book not found");

        //    // Update the existing book with the new details
        //    existingBook.Title = book.Title;
        //    existingBook.Genre = book.Genre;
        //    existingBook.PublishedDate = book.PublishedDate;
        //    existingBook.AuthorId = book.AuthorId;

        //    _context.Entry(existingBook).State = EntityState.Modified;
        //    _context.SaveChanges();
        //}

        //public void DeleteBook(int id)
        //{
        //    var book = _context.Books.Find(id);

        //    if (book == null)
        //        throw new InvalidOperationException("Book not found");

        //    _context.Books.Remove(book);
        //    _context.SaveChanges();
        //}
    }

}
