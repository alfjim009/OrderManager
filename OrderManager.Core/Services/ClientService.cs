namespace OrderManager.Core.Services;

public class ClientService : IClientService
{
  private readonly IClientRepository _clientRepository;

  public ClientService(IClientRepository clientRepository)
  {
    _clientRepository = clientRepository;
  }

  public Task<ClientViewModel> CreateClientAsync(ClientRequest clientRequest)
  {
    return _clientRepository.CreateClientAsync(clientRequest);
  }

  public Task<IEnumerable<ClientViewModel>> GetAllClientsAsync()
  {
    return _clientRepository.GetAllClientsAsync();
  }
}