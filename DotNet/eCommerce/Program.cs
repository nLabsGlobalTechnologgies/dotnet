using eCommerce.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Cors Configurations
builder.Services.AddCors(corsServiceOptions =>
{
    corsServiceOptions.AddDefaultPolicy(corsPolicy =>
    {
        corsPolicy.AllowAnyHeader();
        corsPolicy.AllowAnyMethod();
        corsPolicy.AllowAnyOrigin();
        corsPolicy.AllowCredentials();
    });
});

//SqlServer Configuration Options
string? connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(sqlServerConfigureOptions =>
{
    sqlServerConfigureOptions.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //otomatik olarak Package Manager Console de update-atmam�za gerek kalmadan yapmam�z� saglar a�ag�daki kod ama Development a�amas�nda kullan�lmal�d�r.
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }

    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
