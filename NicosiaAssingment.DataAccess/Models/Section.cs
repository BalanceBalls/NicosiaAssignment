using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NicosiaAssingment.DataAccess.Models;

[Table("Sections")]
public class Section
{
	public int Id { get; set; }
	[Required]
	public string SectionNumber { get; set; }
	public Course Course { get; set; }
	public int CourseId { get; set; }
	public AcademicPeriod Period { get; set; }
	public int PeriodId { get; set; }
	public virtual ICollection<SectionLecturer> SectionLecturers { get; set; }
	public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; }
	public virtual ICollection<Message> MessageTargets { get; set; }
}
