namespace OrderManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private readonly ILogger<ProductsController> _logger;
  private readonly IProductRepository _productService;

  public ProductsController(ILogger<ProductsController> logger, IProductRepository productService)
  {
    _logger = logger;
    _productService = productService;
  }

  [HttpGet]
  [ProducesResponseType(200, Type = typeof(IEnumerable<ProductViewModel>))]
  [ProducesResponseType(404)]
  public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAllClientsAsync()
  {
    var products = await _productService.GetAllProductsAsync();
    return Ok(products);
  }

  [HttpPost]
  [ProducesResponseType(200, Type = typeof(ProductViewModel))]
  [ProducesResponseType(404)]
  public async Task<ActionResult<ProductViewModel>> CreateClientAsync([FromBody] ProductRequest productRequest)
  {
    var product = await _productService.CreateProductAsync(productRequest);
    if (product.IsCompleted == false)
    {
      return BadRequest(product.StatusDetails);
    }

    return Ok(product);
  }
}