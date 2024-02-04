using NewDependencyInjection.Repositories;

var builder = WebApplication.CreateBuilder(args);

//IProductService �agr�ld�g� vakit kar��l�k Olarak ProductService new() yapmak i�in
builder.Services.AddScoped<IProductService, ProductService>();

//builder.Services.AddSingleton<Test1>();
//builder.Services.AddTransient<Test2>();

builder.Services.AddControllers();
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
