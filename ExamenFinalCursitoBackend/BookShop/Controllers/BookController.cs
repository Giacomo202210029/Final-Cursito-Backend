using ExamenFinalCursitoBackend.BookShop.DataAccess.Models;
using ExamenFinalCursitoBackend.BookShop.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFinalCursitoBackend.BookShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = _bookService.GetBookById(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public ActionResult CreateBook([FromBody] Book book)
    {
        //wtf nos ahorramos lo de resources y commands assemblers???
        _bookService.AddBook(book);
        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateBook(int id, [FromBody] Book book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }

        _bookService.UpdateBook(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteBook(int id)
    {
        _bookService.DeleteBook(id);
        return NoContent();
    }
}