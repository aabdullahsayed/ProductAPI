using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


app.MapControllers();

app.Run();