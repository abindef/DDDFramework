using DDDFramework.Domain.Common;

namespace DDDFramework.Domain.OutboundOrder.Events;

public class OutboundCompletedEvent : DomainEvent
{
    public string OrderNo { get; }
    public DateTime CompletedDate { get; }

    public OutboundCompletedEvent(string orderNo, DateTime completedDate)
    {
        OrderNo = orderNo;
        CompletedDate = completedDate;
    }
}
