using System.ComponentModel.DataAnnotations.Schema;

namespace NicosiaAssingment.DataAccess.Models;

[Table("StudentEnrollments")]
public class StudentEnrollment
{
	public int Id { get; set; }
	public Section EnrolledIn { get; set; }
	public int EnrolledInId { get; set; }
	public User Student { get; set; }
	public int StudentId { get; set; }
}
