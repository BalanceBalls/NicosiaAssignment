using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NicosiaAssingment.DataAccess.Models;

namespace NicosiaAssingment.DataAccess.Configurations;

public class SectionsConfiguration : IEntityTypeConfiguration<Section>
{
	public void Configure(EntityTypeBuilder<Section> builder)
	{
	}
}
