using System.ComponentModel.DataAnnotations.Schema;

namespace NicosiaAssingment.DataAccess.Models;

[Table("SectionLecturers")]
public class SectionLecturer
{
	public int Id { get; set; }
	public Section LecturedSection { get; set; }
	public int LecturedSectionId { get; set; }
	public User Lecturer { get; set; }
	public int LecturerId { get; set; }
}
