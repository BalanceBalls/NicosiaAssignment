using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NicosiaAssingment.DataAccess.Models;

[Table("AcademicPeriods")]
public class AcademicPeriod
{
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }
	public DateTimeOffset StartDate { get; set; }
	public DateTimeOffset EndDate { get; set; }
}
