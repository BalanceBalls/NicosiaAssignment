using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NicosiaAssingment.DataAccess.Models;

namespace NicosiaAssingment.DataAccess.Configurations;

public class CoursesConfiguration : IEntityTypeConfiguration<Course>
{
	public void Configure(EntityTypeBuilder<Course> builder)
	{
	}
}
