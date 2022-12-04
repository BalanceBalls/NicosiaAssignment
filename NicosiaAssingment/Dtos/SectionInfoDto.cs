using System.Collections.Generic;

namespace NicosiaAssingment.Dtos;

public class SectionInfoDto
{
	public string SectionNumber { get; set; }
	public AcademicPeriodDto AcademicPeriod { get; set; }
	public CourseDto Course { get; set; }
	public List<LecturerDto> Lecturers { get; set; }
}
