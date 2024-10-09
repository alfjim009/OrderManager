namespace OrderManager.Core.Services;

public class OrderService : IOrderService
{
  private readonly IOrderRepository _orderRepository;

  public OrderService(IOrderRepository orderRepository)
  {
    _orderRepository = orderRepository;
  }

  public Task<OrderViewModel> CreateOrderAsync(OrderRequest orderRequest)
  {
    return _orderRepository.CreateOrderAsync(orderRequest);
  }

  public Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync()
  {
    return _orderRepository.GetAllOrdersAsync();
  }
}