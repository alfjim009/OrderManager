namespace OrderManager.Core.Services;

public interface IOrderService
{
  Task<OrderViewModel> CreateOrderAsync(OrderRequest orderRequest);
}