using OrderManager.Common.ViewModels;
using OrderManager.Common.ViewModels.Request;

namespace OrderManager.Data.Repositories;

public interface IOrderRepository
{
  Task<OrderViewModel> CreateOrderAsync(OrderRequest orderRequest);
}