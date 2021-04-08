using Colaboradix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colaboradix.Infra.Data.Common.Configurations.EntityTypes
{
    internal class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(b => b.Description)
                .HasMaxLength(220);

            builder
                .Property(b => b.Active)
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .HasMany(b => b.Members)
                .WithOne(b => b.Team);

            builder
                .HasMany(b => b.Cycles)
                .WithOne(b => b.Team);
        }
    }
}
