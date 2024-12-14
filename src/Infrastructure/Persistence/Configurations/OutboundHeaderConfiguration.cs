using DDDFramework.Domain.OutboundOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDFramework.Infrastructure.Persistence.Configurations;

public class OutboundHeaderConfiguration : IEntityTypeConfiguration<OutboundHeader>
{
    public void Configure(EntityTypeBuilder<OutboundHeader> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.OrderNo)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.CreatedBy)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.LastModifiedBy)
            .HasMaxLength(50);

        builder.HasIndex(x => x.OrderNo)
            .IsUnique();
    }
}
