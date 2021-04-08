using Colaboradix.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Colaboradix.Infra.Data.EntityTypeConfigurations
{
    public class CycleEntityTypeConfiguration : IEntityTypeConfiguration<Cycle>
    {
        public void Configure(EntityTypeBuilder<Cycle> builder)
        { 
            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.From)
                .IsRequired();

            builder
                .Property(b => b.To)
                .IsRequired();

            builder.HasOne(b => b.Team);

            
        }
    }
}
