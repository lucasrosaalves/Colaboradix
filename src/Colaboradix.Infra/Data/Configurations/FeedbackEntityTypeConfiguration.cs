using Colaboradix.Domain.Constants;
using Colaboradix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colaboradix.Infra.Data.Configurations.EntityTypes
{
    internal class FeedbackEntityTypeConfiguration : IEntityTypeConfiguration<Feedback>
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
                .HasMaxLength(DomainContants.MaxQuantityByFeedback)
                .IsRequired();

            builder.HasOne(b => b.Receiver);

            builder.HasOne(b => b.Sender);

            builder
                .HasOne(b => b.Cycle)
                .WithMany(b=> b.Feedbacks);
        }
    }
}
