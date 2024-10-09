namespace OrderManager.Common.Models;

public class Clients
{
  public int Id { get; set; }

  [Required]
  [MaxLength(100)]
  public string Name { get; set; }

  [MaxLength(100)]
  public string Email { get; set; }

  public IEnumerable<Orders> Orders { get; set; }
}