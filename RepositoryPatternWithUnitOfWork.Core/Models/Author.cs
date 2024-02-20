using System.ComponentModel.DataAnnotations;
namespace RepositoryPatternWithUnitOfWork.Core.Models;
public class Author
{
	public int Id { get; set; }
	[Required, MaxLength(50)]
	public string? Name { get; set; }
	public virtual List<Book>? Books { get; set; }
}
