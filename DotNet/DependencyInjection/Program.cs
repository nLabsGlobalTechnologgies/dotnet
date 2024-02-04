using DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Calculator s�n�f�n� servis olarak ekleyiyoruz, farkl� ya�am d�ng�s� stratejileri ile.
//builder.Services.AddTransient<Calculator>(); // Her istek i�in yeni bir �rnek olu�turulur.
builder.Services.AddScoped<Calculator>();    // Her HTTP iste�i i�in bir �rnek olu�turulur ve bu �rnek t�m HTTP iste�i boyunca kullan�l�r.
//builder.Services.AddSingleton<Calculator>(); // Uygulama ba��na bir �rnek olu�turulur ve bu �rnek uygulama ya�am d�ng�s� boyunca kullan�l�r.

// Web API kontrollerini ekliyoruz.
builder.Services.AddControllers();

// Swagger ve API Explorer i�in servisleri ekliyoruz.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Geli�tirme ortam�nda Swagger UI'yi kullan�labilir hale getiriyoruz.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS'e y�nlendirme eklenmi�.
app.UseHttpsRedirection();

// Kimlik do�rulama eklenmi�.
app.UseAuthorization();

// API kontrolc�lerini e�le�tirme.
app.MapControllers();

app.Run();
