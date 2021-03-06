using Colaboradix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colaboradix.Infra.Mappings
{
    internal class CycleMap : IEntityTypeConfiguration<Cycle>
    {
        public void Configure(EntityTypeBuilder<Cycle> builder)
        {
            builder.ToTable("cycles");

            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.From)
                .IsRequired();

            builder
                .Property(b => b.To)
                .IsRequired();

            builder
                .HasOne(b => b.Team)
                .WithMany(b => b.Cycles);

            builder
                .HasMany(b => b.Feedbacks)
                .WithOne(b => b.Cycle);
        }
    }
}
