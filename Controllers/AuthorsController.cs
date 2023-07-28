using BookManagementSystem.DTOs;
using BookManagementSystem.Entities;
using BookManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _repository;

        public AuthorsController(IAuthorRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: api/authors
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            return Ok(_repository.GetAllAuthors());
        }

        // GET: api/authors/{id}
        [HttpGet("{id}", Name = "GetAuthorById")]
        public ActionResult<Author> GetAuthorById(string id)
        {
            var author = _repository.GetAuthorById(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // POST: api/authors
        [HttpPost]
        public ActionResult<Author> AddAuthor([FromBody] Author author)
        {
            _repository.AddAuthor(author);
            return CreatedAtRoute("GetAuthorById", new { id = author.Id }, author);
        }

        // PUT: api/authors/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(string id, [FromBody] Author author)
        {
            if (author == null || author.Id != id)
            {
                return BadRequest();
            }

            if (_repository.GetAuthorById(id) == null)
            {
                return NotFound();
            }

            _repository.UpdateAuthor(author);

            return NoContent();
        }

        // DELETE: api/authors/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAuthor(string id)
        {
            var author = _repository.GetAuthorById(id);

            if (author == null)
            {
                return NotFound();
            }

            _repository.DeleteAuthor(id);
            return NoContent();
        }
    }







    //[ApiController]
    //[Route("api/[controller]")]
    //public class BooksController : ControllerBase
    //{
    //    private readonly IBookRepository _repository;

    //    public BooksController(IBookRepository repository)
    //    {
    //        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    //    }

    //    //Get all books
    //    [HttpGet]
    //    public ActionResult<IEnumerable<BookDTO>> GetAllBooks()
    //    {
    //        var books = _repository.GetAllBooks();

    //        var bookDTOs = books.Select(b => new BookDTO
    //        {
    //            Title = b.Title,
    //            Genre = b.Genre,
    //            AuthorName = b.Author.Name
    //        }).ToList();

    //        return Ok(bookDTOs);
    //    }

    //    //get specific book
    //    [HttpGet("{id}")]
    //    public ActionResult<BookDTO> GetBookById(string id)
    //    {
    //        var book = _repository.GetBookById(id);

    //        if (book == null)
    //        {
    //            return NotFound();
    //        }

    //        var bookDTO = new BookDTO
    //        {
    //            Title = book.Title,
    //            Genre = book.Genre,
    //            AuthorName = book.Author.Name
    //        };

    //        return Ok(bookDTO);
    //    }

    //    //add a book
    //    [HttpPost]
    //    public ActionResult<BookDTO> AddBook([FromBody] Book book)
    //    {
    //        if (book == null)
    //        {
    //            return BadRequest("Invalid book data");
    //        }

    //        _repository.AddBook(book);

    //        var bookDTO = new BookDTO
    //        {
    //            Title = book.Title,
    //            Genre = book.Genre,
    //            AuthorName = book.Author.Name
    //        };

    //        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, bookDTO);
    //    }

    //    //Update book
    //    [HttpPut("{id}")]
    //    public IActionResult UpdateBook(int id, [FromBody] Book bookToUpdate)
    //    {
    //        if (bookToUpdate == null || id != bookToUpdate.BookId)
    //        {
    //            return BadRequest("Invalid book data");
    //        }

    //        var existingBook = _repository.GetBookById(id);
    //        if (existingBook == null)
    //        {
    //            return NotFound();
    //        }

    //        _repository.UpdateBook(bookToUpdate);

    //        return NoContent();
    //    }

    //    //Delete Book
    //    [HttpDelete("{id}")]
    //    public IActionResult DeleteBook(string id)
    //    {
    //        var book = _repository.GetBookById(id);
    //        if (book == null)
    //        {
    //            return NotFound();
    //        }

    //        _repository.DeleteBook(id);

    //        return NoContent();
    //    }

    //}
}
