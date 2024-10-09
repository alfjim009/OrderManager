namespace OrderManager.Common.ViewModels.Request;

public class OrderRequest
{
  [Required]
  public int ClientId { get; set; }
  public IEnumerable<OrderDetailsRequest> DetailsRequests { get; set; }
}

public class OrderDetailsRequest
{
  [Required]
  public int ProductId { get; set; }

  [Required]
  [Range(1,int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
  public int Amount { get; set; }
}