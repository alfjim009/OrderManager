namespace OrderManager.Core.Services;

public interface IProductService
{
  Task<ProductViewModel> CreateProductAsync(ProductRequest orderRequest);

  Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
}