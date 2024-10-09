namespace OrderManager.Common.Models;

public class Products
{
  public int Id { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
  public int Stock { get; set; }

  public ICollection<OrdersDetails> OrdersDetails { get; set; }
}