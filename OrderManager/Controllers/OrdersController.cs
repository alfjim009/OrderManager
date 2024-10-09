namespace OrderManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
  private readonly ILogger<OrdersController> _logger;
  private readonly IOrderService _orderService;

  public OrdersController(ILogger<OrdersController> logger, IOrderService orderService)
  {
    _logger = logger;
    _orderService =
      _orderService = orderService;
  }

  [HttpPost]
  [ProducesResponseType(200, Type = typeof(OrderViewModel))]
  [ProducesResponseType(404)]
  public async Task<ActionResult<OrderViewModel>> CreateOrder([FromBody] OrderRequest orderRequest)
  {
    var order = await _orderService.CreateOrderAsync(orderRequest);
    if (order.IsCompleted == false)
    {
      return BadRequest(order.StatusDetails);
    }

    return Ok(order);
  }
}