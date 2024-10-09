namespace OrderManager.Common.Models;

public class OrdersDetails
{
  public int Id { get; set; }
  public int OrderId { get; set; }
  public Orders Order { get; set; }

  public int ProductId { get; set; }
  public Products Product { get; set; }

  public int Amount { get; set; }
  public decimal Subtotal { get; set; }
}