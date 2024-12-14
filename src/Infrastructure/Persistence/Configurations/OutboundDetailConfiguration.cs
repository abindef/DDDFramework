using DDDFramework.Domain.OutboundOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDFramework.Infrastructure.Persistence.Configurations;

public class OutboundDetailConfiguration : IEntityTypeConfiguration<OutboundDetail>
{
    public void Configure(EntityTypeBuilder<OutboundDetail> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DetailNo)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.OrderNo)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.ItemCode)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.ItemName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.UnitOfMeasure)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.LocationCode)
            .HasMaxLength(50);

        builder.Property(x => x.CreatedBy)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.LastModifiedBy)
            .HasMaxLength(50);

        builder.HasIndex(x => x.DetailNo)
            .IsUnique();

        builder.HasIndex(x => x.OrderNo);
    }
}
