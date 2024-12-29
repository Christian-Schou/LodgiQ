using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lodgingly.Framework.Infrastructure.Messaging.Outbox;

public sealed class OutboxMessageConsumerConfiguration : IEntityTypeConfiguration<OutboxMessageConsumer>
{
    public void Configure(EntityTypeBuilder<OutboxMessageConsumer> builder)
    {
        builder.ToTable("outbox_message_consumers");
        builder.HasKey(consumer => new { consumer.OutboxMessageId, consumer.Name });
        builder.Property(consumer => consumer.Name).HasMaxLength(500);
    }
}