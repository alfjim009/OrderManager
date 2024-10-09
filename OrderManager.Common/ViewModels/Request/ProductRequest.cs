namespace OrderManager.Common.ViewModels.Request;

public class ProductRequest
{
  [Required]
  [MaxLength(100)]
  public string Name { get; set; }

  [Required]
  public decimal Price { get; set; }

  [Required]
  public int Stock { get; set; }
}