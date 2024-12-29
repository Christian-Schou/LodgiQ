using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lodgingly.Framework.Infrastructure.Messaging.Inbox;

public class InboxMessageConsumerConfiguration : IEntityTypeConfiguration<InboxMessageConsumer>
{
    public void Configure(EntityTypeBuilder<InboxMessageConsumer> builder)
    {
        builder.ToTable("inbox_message_consumers");
        builder.HasKey(consumer => new { consumer.InboxMessageId, consumer.Name });
        builder.Property(consumer => consumer.Name).HasMaxLength(500);
    }
}