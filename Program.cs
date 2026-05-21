//program.cs uygulamanýn kalbidir. yani uygulamanýn ayaða kalktýðý yerdir. bilgisayar açýlýnca BIOS'un çalýþmasý gibi. 

using KitapApi.Services; // servis klasöründeki dosyalarý (IKitapService, KitapService) kullanabilmek için.

var builder = WebApplication.CreateBuilder(args); //her API uygulamasý builder ile baþlar.

builder.Services.AddControllers(); // controllerlarý (kitapController gibi) uygulamaya kaydediyosun yoksa API, controller'larý tanýmaz.
builder.Services.AddEndpointsApiExplorer(); //swagger'ýn API'ndeki endpoint'leri (adresleri) keþfetmesi için. swagger kullanacaksan bu gerekli.
builder.Services.AddSwaggerGen(); // swagger'ýn dokümantasyon sayfasýný oluþturmasýný saðlar.

builder.Services.AddSingleton<IKitapService, KitapService>();  //"birisi IKitapService istediðinde, ona KitapService ver" diye söyleriz. Buna Dependency Injection denir.

var app = builder.Build(); // Builder ile hazýrladýðýmýz uygulamayý inþa eder, çalýþmaya hazýr hale getiririz.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // swagger arayüzünü aktif eder.
    app.UseSwaggerUI(); // swagger arayüzünü aktif eder.
}

app.UseHttpsRedirection(); // HTTP ile gelen istekleri otomatik olarak HTTPS'ye yönlendirir (güvenlik için).
app.UseAuthorization(); // Kimlik doðrulama (JWT token vb.) için hazýrlýk. þu an kullanýlmýyor ilerleyen zamanda eklenecek.
app.MapControllers(); // Controller'lardaki [HttpGet], [HttpPost] gibi atributeleri OKUR ve adresleri (endpoint'leri) oluþturur.
//                     > Çok ÖNEMLÝ! Bunu koymazsan, /api/kitap adresine gidince "404 Not Found" alýrsýn.

app.Run(); // Uygulamayý BAÞLATIR.