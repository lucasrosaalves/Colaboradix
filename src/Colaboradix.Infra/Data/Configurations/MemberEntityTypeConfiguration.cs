using Colaboradix.Domain.Entities;
using Colaboradix.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colaboradix.Infra.Data.Configurations
{
    internal class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("members");

            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(b => b.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(b => b.Active)
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .Property(x => x.Type)
                .HasConversion(p=> p.Id, v => MemberType.FromId(v))
                .HasColumnName("Type")
                .HasDefaultValue(MemberType.Regular)
                .IsRequired();

            builder
                .HasOne(b => b.Team)
                .WithMany(b => b.Members);

            builder
                .HasMany(b => b.ReceivedFeedbacks)
                .WithOne(b => b.Receiver)
                .HasForeignKey(b => b.ReceiverId);

            builder
                .HasMany(b => b.SubmittedFeedbacks)
                .WithOne(b => b.Sender)
                .HasForeignKey(b => b.SenderId);
        }
    }
}
