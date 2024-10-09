namespace OrderManager.Core.Services;

public class ProductService : IProductService
{
  private readonly IProductRepository _productRepository;

  public ProductService(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public Task<ProductViewModel> CreateProductAsync(ProductRequest productRequest)
  {
    return _productRepository.CreateProductAsync(productRequest);
  }

  public Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
  {
    return _productRepository.GetAllProductsAsync();
  }
}