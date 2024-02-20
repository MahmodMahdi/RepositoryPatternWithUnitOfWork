using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOfWork.Core;
using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using RepositoryPatternWithUnitOfWork.Core.Models;

namespace RepositoryPatternWithUnitOfWork.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
	//private readonly IBaseRepository<Author> _authorRepository;
	private readonly IUnitOfWork _unitOfWork;
	public AuthorsController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
	[HttpGet("GetAll")]
	public async Task<IActionResult> GetAll() => Ok(await _unitOfWork.Authors.GetAllAsync());
	[HttpGet("GetById")]
	public async Task<IActionResult> GetById(int id) => Ok(await _unitOfWork.Authors.GetByIdAsync(id)!);
}
