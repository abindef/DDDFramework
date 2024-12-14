using DDDFramework.Domain.OutboundOrder;
using DDDFramework.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DDDFramework.Infrastructure.IntegrationTests.Persistence;

public class ApplicationDbContextTests
{
    private readonly DbContextOptions<ApplicationDbContext> _options;

    public ApplicationDbContextTests()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BufanTestDB;User Id=bufan;Password=234567;")
            .Options;
    }

    [Fact]
    public async Task CanAddAndRetrieveOutboundOrder()
    {
        // Arrange
        var header = new OutboundHeader("TEST001", DateTime.UtcNow, "Test User");
        header.SetDescription("Test Order");

        // Act
        using (var context = new ApplicationDbContext(_options))
        {
            await context.Database.EnsureCreatedAsync();
            context.OutboundHeaders.Add(header);
            await context.SaveChangesAsync();
        }

        // Assert
        using (var context = new ApplicationDbContext(_options))
        {
            var savedHeader = await context.OutboundHeaders
                .FirstOrDefaultAsync(x => x.OrderNo == "TEST001");
            
            Assert.NotNull(savedHeader);
            Assert.Equal("Test Order", savedHeader.Description);
            Assert.Equal("Test User", savedHeader.CreatedBy);
            Assert.Equal(OutboundStatus.Created, savedHeader.Status);
        }
    }
}
