using OrderManager.Common.ViewModels;

namespace OrderManager.Data.Repositories;

public class ClientRepository : IClientRepository
{
  private readonly OrderManagerDbContext _dbContext;

  public ClientRepository(OrderManagerDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<ClientViewModel> CreateClientAsync(ClientRequest clientRequest)
  {
    using var transaction = await _dbContext.Database.BeginTransactionAsync();
    try
    {
      var clientViewModel = new ClientViewModel();

      var newClient = new Clients
      {
        Name = clientRequest.Name,
        Email = clientRequest.Email
      };

      _dbContext.Clients.Add(newClient);

      await _dbContext.SaveChangesAsync();
      await transaction.CommitAsync();

      clientViewModel.ClientId = newClient.Id;
      clientViewModel.Name = newClient.Name;
      clientViewModel.Email = newClient.Email;
      clientViewModel.IsCompleted = true;

      return clientViewModel;
    }
    catch (Exception e)
    {
      await transaction.RollbackAsync();
      throw;
    }
  }

  public async Task<IEnumerable<ClientViewModel>> GetAllClientsAsync()
  {
    var result = await _dbContext.Clients
      .Select(r => new ClientViewModel
      {
        ClientId = r.Id,
        Name = r.Name,
        Email = r.Email
      }).ToListAsync();

    return result;
  }
}