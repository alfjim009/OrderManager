namespace OrderManager.Core.Services;

public interface IOrderService
{
  Task<OrderViewModel> CreateOrderAsync(OrderRequest orderRequest);
  Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync();
}