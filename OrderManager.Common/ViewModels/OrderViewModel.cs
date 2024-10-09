namespace OrderManager.Common.ViewModels;

public class OrderViewModel : BaseViewModel
{
  public DateTime Date { get; set; }
  public int ClientId { get; set; }
  public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }
}

public class OrderDetailViewModel
{
  public int ProductId { get; set; }
  public int Amount { get; set; }
  public decimal SubTotal { get; set; }
}