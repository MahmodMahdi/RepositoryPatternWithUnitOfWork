using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using System.Linq.Expressions;

namespace RepositoryPatternWithUnitOfWork.EF.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
	protected ApplicationDbContext _context;
	public BaseRepository(ApplicationDbContext context) => _context = context;
	public async Task<T> GetByIdAsync(int id) => (await _context.Set<T>().FindAsync(id))!;
	public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
	public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] include = null!)
	{
		IQueryable<T> query = _context.Set<T>();
		if (include != null)
			foreach (var includeValue in include)
				query = query.Include(includeValue);

		return (await query.SingleOrDefaultAsync(criteria))!;
	}
	public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] include = null!)
	{ 
		IQueryable<T> query = _context.Set<T>();
		if (include != null)
			foreach (var includeValue in include)
				query = query.Include(includeValue);

		return (await query.Where(criteria).ToListAsync());
	}
	//another way to findAll
	public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
	{
		return (await _context.Set<T>().Skip(skip).Take(take).ToListAsync());
	}
	//Another way and include every thing i need
    public	async Task<T> AddAsync(T book)
	{
		await _context.Set<T>().AddAsync(book);
		await _context.SaveChangesAsync();
		return book;
	}
	public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> books)
	{
		await _context.Set<T>().AddRangeAsync(books);
		await _context.SaveChangesAsync();
		return books;
	}
	public T Update(T Book)
	{
	    _context.Update(Book);
		return Book;

	}
	public void Delete(T Book)
	{
		_context.Set<T>().Remove(Book);
		_context.SaveChanges();
	}
	public void DeleteRange(IEnumerable<T> Books)
	{
		_context.Set<T>().RemoveRange(Books);
		_context.SaveChanges();
	}
	//public void Attach(T Book)
	//{
	//	_context.Set<T>().Attach(Book);
	//}
	//public int Count()
	//{
	//	return _context.Set<T>().Count();
	//}
	//public int Count(Expression<Func<T, bool>> criteria)
	//{
	//	return _context.Set<T>().Count(criteria);
	//}
}
