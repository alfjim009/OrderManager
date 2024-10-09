using OrderManager.Common.ViewModels;

namespace OrderManager.Data.Repositories;

public class ProductRepository : IProductRepository
{
  private readonly OrderManagerDbContext _dbContext;

  public ProductRepository(OrderManagerDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<ProductViewModel> CreateProductAsync(ProductRequest productRequest)
  {
    using var transaction = await _dbContext.Database.BeginTransactionAsync();
    try
    {
      var productViewModel = new ProductViewModel();

      var newProduct = new Products()
      {
        Name = productRequest.Name,
        Price = productRequest.Price,
        Stock = productRequest.Stock
      };

      _dbContext.Products.Add(newProduct);

      await _dbContext.SaveChangesAsync();
      await transaction.CommitAsync();

      productViewModel.Name = newProduct.Name;
      productViewModel.ProductId = newProduct.Id;
      productViewModel.Price = newProduct.Price;
      productViewModel.Stock = newProduct.Stock;
      productViewModel.IsCompleted = true;

      return productViewModel;
    }
    catch (Exception e)
    {
      await transaction.RollbackAsync();
      throw;
    }
  }

  public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
  {
    var result = await _dbContext.Products
      .Select(r => new ProductViewModel
      {
        Name = r.Name,
        ProductId = r.Id,
        Price = r.Price,
        Stock = r.Stock
      }).ToListAsync();

    return result;
  }
}