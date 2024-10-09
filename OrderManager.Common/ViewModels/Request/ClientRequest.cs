namespace OrderManager.Common.ViewModels.Request;

public class ClientRequest
{
  [Required] 
  [MaxLength(100)]
  public string Name { get; set; }

  [EmailAddress]
  [MaxLength(100)]
  public string Email { get; set; }
}