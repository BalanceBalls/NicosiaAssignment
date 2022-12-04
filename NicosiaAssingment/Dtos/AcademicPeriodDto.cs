using System;

namespace NicosiaAssingment.Dtos;

public class AcademicPeriodDto
{
	public string Name { get; set; }
	public DateTimeOffset StartDate { get; set; }
	public DateTimeOffset EndDate { get; set; }
}
