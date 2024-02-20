using RepositoryPatternWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.Core.Dtos
{
	public class BookDto
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public int AuthorId { get; set; }
	}
}
