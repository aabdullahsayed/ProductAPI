using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();


app.MapControllers();

app.Run();