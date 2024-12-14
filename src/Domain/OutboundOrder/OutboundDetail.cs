using DDDFramework.Domain.Common;

namespace DDDFramework.Domain.OutboundOrder;

public class OutboundDetail : AggregateRoot
{
    public string DetailNo { get; private set; } = null!;
    public string OrderNo { get; private set; } = null!;
    public string ItemCode { get; private set; } = null!;
    public string ItemName { get; private set; } = null!;
    public decimal Quantity { get; private set; }
    public string UnitOfMeasure { get; private set; } = null!;
    public OutboundDetailStatus Status { get; private set; }
    public string? LocationCode { get; private set; }
    public string CreatedBy { get; private set; } = null!;
    public DateTime CreatedTime { get; private set; }
    public string? LastModifiedBy { get; private set; }
    public DateTime? LastModifiedTime { get; private set; }

    private OutboundDetail() { } // For EF Core

    public OutboundDetail(
        string detailNo,
        string orderNo,
        string itemCode,
        string itemName,
        decimal quantity,
        string unitOfMeasure,
        string createdBy)
    {
        DetailNo = detailNo;
        OrderNo = orderNo;
        ItemCode = itemCode;
        ItemName = itemName;
        Quantity = quantity;
        UnitOfMeasure = unitOfMeasure;
        CreatedBy = createdBy;
        CreatedTime = DateTime.UtcNow;
        Status = OutboundDetailStatus.Created;
    }

    public void AssignLocation(string locationCode, string modifiedBy)
    {
        LocationCode = locationCode;
        LastModifiedBy = modifiedBy;
        LastModifiedTime = DateTime.UtcNow;
    }

    public void UpdateStatus(OutboundDetailStatus status, string modifiedBy)
    {
        Status = status;
        LastModifiedBy = modifiedBy;
        LastModifiedTime = DateTime.UtcNow;
    }
}
