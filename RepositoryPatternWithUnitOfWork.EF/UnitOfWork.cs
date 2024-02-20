using RepositoryPatternWithUnitOfWork.Core;
using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.EF.Repositories;

namespace RepositoryPatternWithUnitOfWork.EF
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		public IBaseRepository<Author> Authors { get; private set; }
		public IBooksRepository Books { get; private set; }
		public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
			Authors = new BaseRepository<Author> (_context);
			Books = new BooksRepository(_context);
        }
		
		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
