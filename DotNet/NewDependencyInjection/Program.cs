using NewDependencyInjection.Repositories;

var builder = WebApplication.CreateBuilder(args);

//IProductService çagrýldýgý vakit karþýlýk Olarak ProductService new() yapmak için
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
