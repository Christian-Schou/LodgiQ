using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LodgiQ.Framework.Infrastructure.Messaging.Inbox;

public sealed class InboxMessageConfiguration : IEntityTypeConfiguration<InboxMessage>
{
    public void Configure(EntityTypeBuilder<InboxMessage> builder)
    {
        builder.ToTable("inbox_messages");
        builder.HasKey(msg => msg.Id);
        builder.Property(msg => msg.Content).HasMaxLength(2000).HasColumnType("jsonb");
    }
}