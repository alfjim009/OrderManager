namespace OrderManager.Data.Repositories;

public interface IProductRepository
{
  Task<ProductViewModel> CreateProductAsync(ProductRequest orderRequest);

  Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
}