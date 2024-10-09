namespace OrderManager.Data.Repositories;

public class OrderRepository : IOrderRepository
{
  private readonly OrderManagerDbContext _dbContext;

  public OrderRepository(OrderManagerDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<OrderViewModel> CreateOrderAsync(OrderRequest orderRequest)
  {
    using var transaction = await _dbContext.Database.BeginTransactionAsync();
    try
    {
      var orderViewModel = new OrderViewModel();
      var client = await _dbContext.Clients.FindAsync(orderRequest.ClientId);

      if (client == null)
      {
        orderViewModel.IsCompleted = false;
        orderViewModel.StatusDetails = "El cliente no existe.";

        return orderViewModel;
      }

      var newOrder = new Orders
      {
        ClientId = orderRequest.ClientId,
        Date = DateTime.Now
      };

      _dbContext.Orders.Add(newOrder);
      await _dbContext.SaveChangesAsync();

      foreach (var orderDetailRequest in orderRequest.DetailsRequests)
      {
        var product = await _dbContext.Products.FindAsync(orderDetailRequest.ProductId);
        if (product == null)
        {
          orderViewModel.IsCompleted = false;
          orderViewModel.StatusDetails = $"El producto con ID {orderDetailRequest.ProductId} no existe.";

          return orderViewModel;
        }

        if (product.Stock < orderDetailRequest.Amount)
        {
          orderViewModel.IsCompleted = false;
          orderViewModel.StatusDetails = $"No hay suficiente stock para el product {product.Name}.";

          return orderViewModel;
        }

        product.Stock -= orderDetailRequest.Amount;

        var orderDetail = new OrdersDetails
        {
          OrderId = newOrder.Id,
          ProductId = orderDetailRequest.ProductId,
          Amount = orderDetailRequest.Amount,
          Subtotal = product.Price * orderDetailRequest.Amount
        };

        _dbContext.OrdersDetails.Add(orderDetail);
      }

      await _dbContext.SaveChangesAsync();
      await transaction.CommitAsync();

      orderViewModel.ClientId = newOrder.ClientId;
      orderViewModel.Date = newOrder.Date;
      orderViewModel.IsCompleted = true;
      orderViewModel.StatusDetails = "Success!";

      return orderViewModel;
    }
    catch (Exception e)
    {
      await transaction.RollbackAsync();
      throw;
    }
  }

  public async Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync()
  {
    var result = await _dbContext.Orders
      .Include(c=> c.OrdersDetails)
      .Select(r => new OrderViewModel
      {
        Date = r.Date,
        ClientId = r.ClientId,
        OrderDetails = r.OrdersDetails.Select(o => new OrderDetailViewModel
        {
          ProductId = o.ProductId,
          Amount = o.Amount,
          SubTotal = o.Subtotal
        })
      }).ToListAsync();

    return result;
  }
}