using BookManagementSystem.Entities;
using System.Collections.Generic;

namespace BookManagementSystem.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(string id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(string id);
        Author GetAuthorByName(string name);

        /*
         * IEnumerable<Book> GetAllBooks();
        Book GetBookById(string id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(string id);*/
    }
}
