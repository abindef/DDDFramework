using DDDFramework.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDFramework.Infrastructure.Persistence.Configurations;

public class DomainEventConfiguration : IEntityTypeConfiguration<DomainEvent>
{
    public void Configure(EntityTypeBuilder<DomainEvent> builder)
    {
        builder.HasKey("_id"); // 添加一个隐藏的主键字段
        builder.Property<int>("_id").ValueGeneratedOnAdd();
        builder.Ignore(e => e.IsPublished);
    }
}
