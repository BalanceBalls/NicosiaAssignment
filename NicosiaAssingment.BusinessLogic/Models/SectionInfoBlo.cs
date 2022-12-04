using NicosiaAssingment.DataAccess.Models;
using System.Collections.Generic;
namespace NicosiaAssingment.BusinessLogic.Models;

public class SectionInfoBlo
{
	public string SectionNumber { get; set; }
	public AcademicPeriodBlo AcademicPeriod { get; set; }
	public CourseBlo Course { get; set; }
	public List<LecturerBlo> Lecturers { get; set; }
	public List<StudentEnrollment> StudentEnrollments { get; set; }
}
