using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NicosiaAssingment.DataAccess.Models;

namespace NicosiaAssingment.DataAccess.Configurations;

public class AcademicPeriodsConfiguration : IEntityTypeConfiguration<AcademicPeriod>
{
	public void Configure(EntityTypeBuilder<AcademicPeriod> builder)
	{
	}
}
