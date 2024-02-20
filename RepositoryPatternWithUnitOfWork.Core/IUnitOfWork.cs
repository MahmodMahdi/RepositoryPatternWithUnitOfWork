using RepositoryPatternWithUnitOfWork.Core.Interfaces;
using RepositoryPatternWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.Core
{
    public interface IUnitOfWork : IDisposable
	{
		IBaseRepository<Author> Authors { get; }
        IBooksRepository Books { get; }
		int Complete();
	}
}
