using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Context;
using RepositoryDesignPattern.Interfaces;
using RepositoryDesignPattern.Repositories.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<AppDbContext>(sqlServerConfiguretionOptions =>
{
    sqlServerConfiguretionOptions.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ShoppingCartRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<IUnitOfWork>(unitOfWorkService => unitOfWorkService.GetRequiredService<AppDbContext>());

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
