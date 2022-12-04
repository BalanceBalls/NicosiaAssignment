using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NicosiaAssingment.DataAccess.Models;

namespace NicosiaAssingment.DataAccess.Configurations;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasIndex(x => x.Email).IsUnique();
	}
}
