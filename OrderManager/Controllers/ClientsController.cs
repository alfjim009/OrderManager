namespace OrderManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
  private readonly ILogger<ClientsController> _logger;
  private readonly IClientService _clientService;

  public ClientsController(ILogger<ClientsController> logger, IClientService clientService)
  {
    _logger = logger;
    _clientService = clientService;
  }

  [HttpGet]
  [ProducesResponseType(200, Type = typeof(IEnumerable<ClientViewModel>))]
  [ProducesResponseType(404)]
  public async Task<ActionResult<IEnumerable<ClientViewModel>>> GetAllClientsAsync()
  {
    var clients = await _clientService.GetAllClientsAsync();
    return Ok(clients);
  }

  [HttpPost]
  [ProducesResponseType(200, Type = typeof(ClientViewModel))]
  [ProducesResponseType(404)]
  public async Task<ActionResult<ClientViewModel>> CreateClientAsync([FromBody] ClientRequest clientRequest)
  {
    var client = await _clientService.CreateClientAsync(clientRequest);
    if (client.IsCompleted == false)
    {
      return BadRequest(client.StatusDetails);
    }

    return Ok(client);
  }
}