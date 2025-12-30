using API.Data;
using Microsoft.EntityFrameworkCore;

/*
Ne yapıyor? Web uygulaman için bir "inşaatçı" (builder) oluşturuyor.

Detay: Bu satır arka planda varsayılan ayarları yükler (örneğin: appsettings.json dosyasını okumaya başlar, loglama mekanizmasını kurar).
*/
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
Ne yapıyor? Projeye "Controller" yapısını ekliyor.

Neden? Sen bir Web API yapıyorsun. Eğer MVC projesi yapsaydın AddControllersWithViews() derdik. Bu kod, uygulamanın HTTP isteklerini (GET, POST vb.) karşılayan sınıfları (Controllers) tanımasını sağlar.
*/
builder.Services.AddControllers();


builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200","https://localhost:4200"));
app.MapControllers();

app.Run();

/*
    Builder ve App aşaması olarak ikiye ayrılır.
    Builder aşamasında servisler eklenir ve yapılandırılır.
    App aşamasında ise middleware'ler yapılandırılır ve uygulama çalıştırılır.
*/
