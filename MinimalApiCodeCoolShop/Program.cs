using Data;
using Microsoft.EntityFrameworkCore;
using MinimalApiCodeCoolShop.Services.Products;
using SimpleApi.SecretSauce;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointDefinitions(typeof(ProductService));

IConfiguration configuration = new ConfigurationBuilder()
							.AddJsonFile("appsettings.json")
							.Build();

builder.Services.AddDbContext<CodecoolshopContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("CodecoolShopConnectionString")));

var app = builder.Build();
app.UseEndpointDefinitions();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
