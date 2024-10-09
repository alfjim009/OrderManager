namespace OrderManager.Common.ViewModels;

public class OrderViewModel
{
  public DateTime Date { get; set; }
  public int ClientId { get; set; }
  public bool IsCompleted { get; set; }
  public string StatusDetails { get; set; }
}