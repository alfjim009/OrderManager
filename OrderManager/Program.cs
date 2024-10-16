namespace OrderManager
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      var configuration = builder.Configuration;

      // Add services to the container.
      builder.Services.AddScoped<IOrderRepository, OrderRepository>();
      builder.Services.AddScoped<IOrderService, OrderService>();

      builder.Services.AddScoped<IClientRepository, ClientRepository>();
      builder.Services.AddScoped<IClientService, ClientService>();

      builder.Services.AddScoped<IProductRepository, ProductRepository>();
      builder.Services.AddScoped<IProductService, ProductService>();

      builder.Services.AddDbContext<OrderManagerDbContext>(
        options => options
          .UseSqlServer(configuration.GetConnectionString("DbContext") ?? "")
          .EnableSensitiveDataLogging()
      );

      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();

      app.MapControllers();

      app.Run();
    }
  }
}