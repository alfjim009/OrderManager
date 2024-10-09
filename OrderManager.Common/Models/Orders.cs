namespace OrderManager.Common.Models;

public class Orders
{
  public int Id { get; set; }
  public DateTime Date { get; set; }
  public int ClientId { get; set; }
  public Clients Client { get; set; }

  public ICollection<OrdersDetails> OrdersDetails { get; set; }
}