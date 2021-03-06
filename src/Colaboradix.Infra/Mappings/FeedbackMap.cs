using Colaboradix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colaboradix.Infra.Mappings
{
    internal class FeedbackMap : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("feedbacks");

            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.Message)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(b => b.Quantity)
                .HasMaxLength(Feedback.MaxQuantity)
                .IsRequired();

            builder.HasOne(b => b.Receiver);

            builder.HasOne(b => b.Sender);

            builder
                .HasOne(b => b.Cycle)
                .WithMany(b=> b.Feedbacks);
        }
    }
}
