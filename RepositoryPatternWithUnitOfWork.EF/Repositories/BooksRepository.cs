using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using RepositoryPatternWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.EF.Repositories
{
	public class BooksRepository : BaseRepository<Book> ,IBooksRepository
	{
		private readonly ApplicationDbContext _context;
        public BooksRepository(ApplicationDbContext context):base (context)
        {
        }
        public IEnumerable<Book> Special()
		{
			throw new NotImplementedException();
		}
	}
}
