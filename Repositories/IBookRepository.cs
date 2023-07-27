using BookManagementSystem.Entities;
using System.Collections.Generic;

namespace BookManagementSystem.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(string id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(string id);
    }

}
