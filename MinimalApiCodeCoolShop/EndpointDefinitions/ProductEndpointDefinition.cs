using MinimalApiCodeCoolShop.Services.Products;
using SimpleApi.SecretSauce;

namespace MinimalApiCodeCoolShop.EndPointDefinitions
{
	public class ProductEndpointDefinition : IEndpointDefinition
	{
		public void DefineEndpoints(WebApplication app)
		{
			app.MapGet("/products", (IProductService productService) => productService.GetAllProducts());
		}

		public void DefineServices(IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
		}
	}
}
