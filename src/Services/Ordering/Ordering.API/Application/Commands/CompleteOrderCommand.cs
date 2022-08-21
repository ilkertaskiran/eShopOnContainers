namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands;

public class CompleteOrderCommand : IRequest<bool>
{

    [DataMember]
    public int OrderNumber { get; set; }
    
    [DataMember]
    public DateTime OrderDate { get; set; }
    
    [DataMember]
    public DateTime ArrivalDate { get; set; }

    [DataMember]
    public string UserId { get; private set; }

    public CompleteOrderCommand()
    {

    }
    public CompleteOrderCommand(int orderNumber, Datetime orderDate, string userId)
    {
        OrderNumber = orderNumber;
        OrderDate = orderDate;
        UserId = userId;
        ArrivalDate = new DateTime.UtcNow;
    }
}
