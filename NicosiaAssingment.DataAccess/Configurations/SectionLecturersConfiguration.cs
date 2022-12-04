using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NicosiaAssingment.DataAccess.Models;


namespace NicosiaAssingment.DataAccess.Configurations;

public class SectionLecturersConfiguration : IEntityTypeConfiguration<SectionLecturer>
{
	public void Configure(EntityTypeBuilder<SectionLecturer> builder)
	{
		builder.HasKey(de => new { de.LecturerId, de.LecturedSectionId });
	}
}
