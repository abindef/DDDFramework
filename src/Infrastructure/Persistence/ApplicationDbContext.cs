using DDDFramework.Domain.OutboundOrder;
using Microsoft.EntityFrameworkCore;

namespace DDDFramework.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<OutboundHeader> OutboundHeaders { get; set; }
    public DbSet<OutboundDetail> OutboundDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
