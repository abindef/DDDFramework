using DDDFramework.Domain.OutboundOrder.Events;
using Dapr.Client;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DDDFramework.Application.OutboundOrder.EventHandlers;

public class OutboundCompletedEventHandler : INotificationHandler<OutboundCompletedEvent>
{
    private readonly DaprClient _daprClient;
    private readonly ILogger<OutboundCompletedEventHandler> _logger;

    public OutboundCompletedEventHandler(DaprClient daprClient, ILogger<OutboundCompletedEventHandler> logger)
    {
        _daprClient = daprClient;
        _logger = logger;
    }

    public async Task Handle(OutboundCompletedEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            // 使用 Dapr 发布事件
            await _daprClient.PublishEventAsync(
                "pubsub", // Dapr pubsub 组件名称
                "outbound-completed", // 事件主题
                new { notification.OrderNo, notification.CompletedDate },
                cancellationToken);

            _logger.LogInformation("Published outbound completed event for order {OrderNo}", notification.OrderNo);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error publishing outbound completed event for order {OrderNo}", notification.OrderNo);
            throw;
        }
    }
}
