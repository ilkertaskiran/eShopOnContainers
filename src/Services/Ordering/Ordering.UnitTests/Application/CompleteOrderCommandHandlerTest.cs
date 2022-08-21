using Microsoft.eShopOnContainers.Services.Ordering.API.Application.IntegrationEvents;

namespace UnitTest.Ordering.Application;

using Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate;

public class CompleteOrderRequestHandlerTest
{
    private readonly Mock<IOrderRepository> _orderRepositoryMock;
    private readonly Mock<IIdentityService> _identityServiceMock;
    private readonly Mock<IMediator> _mediator;
    private readonly Mock<IOrderingIntegrationEventService> _orderingIntegrationEventService;

    public CompleteOrderRequestHandlerTest()
    {

        _orderRepositoryMock = new Mock<IOrderRepository>();
        _identityServiceMock = new Mock<IIdentityService>();
        _orderingIntegrationEventService = new Mock<IOrderingIntegrationEventService>();
        _mediator = new Mock<IMediator>();
    }

    [Fact]
    public async Task Handle_return_false_if_order_is_not_persisted()
    {
        var fakeOrderCmd = new Dictionary<string, object>
        {
            ["OrderNumber"] = 1,
            ["OrderDate"] = Datetime.Now,
            ["ArrivalDate"] = Datetime.Now,
            ["UserId"] = "B5LISHH"
        };

        var LoggerMock = new Mock<ILogger<CreateOrderCommandHandler>>();
        //Act
        var handler = new CreateOrderCommandHandler(_mediator.Object, _orderingIntegrationEventService.Object, _orderRepositoryMock.Object, _identityServiceMock.Object, LoggerMock.Object);
        var cltToken = new System.Threading.CancellationToken();
        var result = await handler.Handle(fakeOrderCmd, cltToken);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void Handle_throws_exception_when_no_orderd()
    {
        //Assert
        Assert.Throws<ArgumentNullException>(() => new Order(string.Empty, string.Empty));
    }

}
