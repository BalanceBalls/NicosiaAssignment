using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NicosiaAssingment.DataAccess.Models;

[Table("Courses")]
public class Course
{
	public int Id { get; set; }
	[Required]
	public string Code { get; set; }
	[Required]
	public string Title { get; set; }
}
