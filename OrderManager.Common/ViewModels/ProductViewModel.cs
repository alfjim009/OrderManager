namespace OrderManager.Common.ViewModels;

public class ProductViewModel : BaseViewModel
{
  public int ProductId { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
  public int Stock { get; set; }
}