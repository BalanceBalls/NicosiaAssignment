using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NicosiaAssingment.DataAccess.Models;

namespace NicosiaAssingment.DataAccess.Configurations;

public class StudentEnrollmentsConfiguration : IEntityTypeConfiguration<StudentEnrollment>
{
	public void Configure(EntityTypeBuilder<StudentEnrollment> builder)
	{
		builder.HasKey(de => new { de.StudentId, de.EnrolledInId });
	}
}
