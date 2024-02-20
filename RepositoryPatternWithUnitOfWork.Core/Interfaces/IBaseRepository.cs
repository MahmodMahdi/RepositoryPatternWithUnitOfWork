using System.Collections;
using System.Linq.Expressions;

namespace RepositoryPatternWithUnitOfWork.Core.Interfaces;
public interface IBaseRepository<T> where T : class
{
	Task<T>? GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
	Task<T> FindAsync(Expression<Func<T, bool>> criteria,string[] include =null!);
	Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] include = null!);
	//Another way to find all
	Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take,int skip);
	Task<T> AddAsync(T Book);
	Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T>books);
	T Update(T Book);
	void Delete(T Book);
	void DeleteRange(IEnumerable<T> Book);
	//void Attach(T Book);
	//int Count();
	//int Count(Expression<Func<T, bool>> criteria);
}

