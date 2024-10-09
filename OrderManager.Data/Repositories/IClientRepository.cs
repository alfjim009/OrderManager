namespace OrderManager.Data.Repositories;

public interface IClientRepository
{
  Task<ClientViewModel> CreateClientAsync(ClientRequest orderRequest);
  Task<IEnumerable<ClientViewModel>> GetAllClientsAsync();
}