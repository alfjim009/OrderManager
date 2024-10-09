namespace OrderManager.Core.Services;

public interface IClientService
{
  Task<ClientViewModel> CreateClientAsync(ClientRequest orderRequest);

  Task<IEnumerable<ClientViewModel>> GetAllClientsAsync();
}