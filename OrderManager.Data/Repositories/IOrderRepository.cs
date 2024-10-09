namespace OrderManager.Data.Repositories;

public interface IOrderRepository
{
  Task<OrderViewModel> CreateOrderAsync(OrderRequest orderRequest);
  Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync();
}