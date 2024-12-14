using DDDFramework.Domain.Common;
using DDDFramework.Domain.OutboundOrder.Events;

namespace DDDFramework.Domain.OutboundOrder;

public class OutboundHeader : AggregateRoot
{
    public string OrderNo { get; private set; } = null!;
    public DateTime OrderDate { get; private set; }
    public string? Description { get; private set; }
    public OutboundStatus Status { get; private set; }
    public string CreatedBy { get; private set; } = null!;
    public DateTime CreatedTime { get; private set; }
    public string? LastModifiedBy { get; private set; }
    public DateTime? LastModifiedTime { get; private set; }

    private OutboundHeader() { } // For EF Core

    public OutboundHeader(string orderNo, DateTime orderDate, string createdBy)
    {
        OrderNo = orderNo;
        OrderDate = orderDate;
        CreatedBy = createdBy;
        CreatedTime = DateTime.UtcNow;
        Status = OutboundStatus.Created;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void UpdateStatus(OutboundStatus status, string modifiedBy)
    {
        var oldStatus = Status;
        Status = status;
        LastModifiedBy = modifiedBy;
        LastModifiedTime = DateTime.UtcNow;

        if (oldStatus != OutboundStatus.Completed && status == OutboundStatus.Completed)
        {
            AddDomainEvent(new OutboundCompletedEvent(OrderNo, LastModifiedTime.Value));
        }
    }
}
