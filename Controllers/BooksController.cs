using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWork.Core;
using RepositoryPatternWithUnitOfWork.Core.Dtos;
using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using RepositoryPatternWithUnitOfWork.Core.Models;

namespace RepositoryPatternWithUnitOfWork.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
	//private readonly IBaseRepository<Book> _bookRepository;
	private readonly IUnitOfWork _unitOfWork;
	public BooksController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
	[HttpGet("GetAll")]
	public async Task<IActionResult> GetAll() => Ok(await _unitOfWork.Books.GetAllAsync());
	[HttpGet("GetById",Name = "BookDetailsRoute")]
	public async Task<IActionResult> GetById(int id) => Ok(await _unitOfWork.Books.GetByIdAsync(id)!);
	[HttpGet("GetByName")]
	public async Task<IActionResult> GetByName(string name) => Ok(await _unitOfWork.Books.FindAsync(b => b.Title == name, new[] { "Author" }));
	[HttpGet("GetAllWithAuthors")]
	public async Task<IActionResult> GetAllWithAuthors(string name) => Ok(await _unitOfWork.Books.FindAllAsync(b => b.Title!.Contains(name), new[] { "Author" }));
	//Another Way to GetAll
	[HttpGet("GetAllBooksWithAuthor")]
	public async Task<IActionResult> GetAllWithAuthor(string name) => Ok(await _unitOfWork.Books.FindAllAsync(b => b.Title!.Contains(name), new[] { "Author" }));
	[HttpPost("AddBook")]
	public async Task<ActionResult<BookDto>> Post(BookDto book)
	{
		if (ModelState.IsValid)
		{
			var Book = new Book();
			Book.Id = book.Id;
			Book.Title = book.Title;
			Book.AuthorId = book.AuthorId;
			await _unitOfWork.Books.AddAsync(Book);
			string url = Url.Link("BookDetailsRoute", new { id = book.Id })!;
			return Created(url, Book);
		}
		else
			return BadRequest();
	}
	[HttpPost]
	public async Task<ActionResult> AddOne()
	{
		var book =await _unitOfWork.Books.AddAsync(new Book { Title = "Time", AuthorId = 1 });
		_unitOfWork.Complete();  // instead of save changes , unit of work make it
		return Ok(book);
	}
}

