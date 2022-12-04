using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NicosiaAssingment.DataAccess.Models;

namespace NicosiaAssingment.DataAccess.Configurations;

public class MessagesConfiguration : IEntityTypeConfiguration<Message>
{
	public void Configure(EntityTypeBuilder<Message> builder)
	{
		builder.ToTable("Messages");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.IsApproved).IsRequired();
		builder.Property(x => x.Content).IsRequired();
		builder.Property(x => x.ApproverId);
		builder.Property(x => x.SenderId).IsRequired();
		builder.Property(x => x.TargetSectionId).IsRequired();

		builder.HasOne(x => x.Approver)
			.WithMany(u => u.Approvers)
			.HasForeignKey(x => x.ApproverId)
			.OnDelete(DeleteBehavior.ClientSetNull);

		builder.HasOne(x => x.Sender)
			.WithMany(u => u.Senders)
			.HasForeignKey(x => x.SenderId)
			.OnDelete(DeleteBehavior.ClientSetNull);

		builder.HasOne(x => x.TargetSection)
			.WithMany(s => s.MessageTargets)
			.HasForeignKey(x => x.TargetSectionId)
			.OnDelete(DeleteBehavior.ClientSetNull);
	}
}
