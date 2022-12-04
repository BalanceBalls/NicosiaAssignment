using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NicosiaAssingment.DataAccess.Models;

[Table("Users")]
public class User
{
	public int Id { get; set; }
	[Required]
	public string FirstName { get; set; }
	[Required]
	public string LastName { get; set; }
	[Required]
	public string Phone { get; set; }
	[Required]
	public string Email { get; set; }
	public string InsuranceNumber { get; set; }
	[Required]
	public string Role { get; set; }
	[Required]
	public string PwdHash { get; set; }

	public virtual ICollection<SectionLecturer> SectionLecturers { get; set; }
	public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; }
	public virtual ICollection<Message> Senders { get; set; }
	public virtual ICollection<Message> Approvers { get; set; }
}
