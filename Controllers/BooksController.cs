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
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BooksController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        //GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            var bookDTOs = books.Select(book =>
            {
                var author = _authorRepository.GetAuthorById(book.AuthorId); //getting author name from other collection using object id
                return new BookDTO
                {
                    Title = book.Title,
                    Genre = book.Genre,
                    AuthorName = author?.Name 
                };
            });

            return Ok(bookDTOs);
        }

        //GET: api/Books/{id}
        [HttpGet("{id}", Name = "GetBookById")]
        public ActionResult<BookDTO> GetBookById(string id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var author = _authorRepository.GetAuthorById(book.AuthorId);//getting author name from other collection using id

            var bookDTO = new BookDTO
            {
                Title = book.Title,
                Genre = book.Genre,
                AuthorName = author?.Name 
            };

            return Ok(bookDTO);
        }

        //PSOT: api/Books
        [HttpPost]
        public ActionResult<BookDTO> AddBook([FromBody] BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return BadRequest("Invalid book data");
            }

            // Check if the author already exists
            var existingAuthor = _authorRepository.GetAuthorByName(bookDTO.AuthorName);

            Author author;
            if (existingAuthor == null)
            {
                // Create the author
                author = new Author { Name = bookDTO.AuthorName };
                _authorRepository.AddAuthor(author);
            }
            else
            {
                author = existingAuthor;
            }

            // Create the book with the author's ID
            var book = new Book
            {
                Title = bookDTO.Title,
                Genre = bookDTO.Genre,
                AuthorId = author.Id
            };

            _bookRepository.AddBook(book);

            var responseBookDTO = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                AuthorName = author.Name
            };

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, responseBookDTO);
        }



        //[HttpPost]
        //public ActionResult<BookDTO> AddBook([FromBody] Book book)
        //{
        //    if (book == null)
        //    {
        //        return BadRequest("Invalid book data");
        //    }

        //    _bookRepository.AddBook(book);
        //    var author = _authorRepository.GetAuthorById(book.AuthorId); //getting author name from other collection using id

        //    var bookDTO = new BookDTO
        //    {
        //        Title = book.Title,
        //        Genre = book.Genre,
        //        AuthorName = author?.Name  
        //    };

        //    return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, bookDTO);
        //}

        // PUT: api/Books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(string id, [FromBody] Book book)
        {
            if (book == null || book.Id != id)
            {
                return BadRequest();
            }

            if (_bookRepository.GetBookById(id) == null)
            {
                return NotFound();
            }

            _bookRepository.UpdateBook(book);

            return NoContent();
        }

        // DELETE: api/Books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.DeleteBook(id);

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
