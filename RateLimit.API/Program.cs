using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region appsettings.json okumak için gerekli servis
builder.Services.AddOptions();
#endregion
#region Cache servis eklenmelidir.
builder.Services.AddMemoryCache();//dakikakada 100 istek yapýlsýn dediðimiz zaman bu 100 isteði memory de tutacak. Bu servis sayesinde.
#endregion

#region appsettings.json içinden okuyacaðý keyleri belirleyelim.

#region appsettings.json içindeki key deðerindeki ayarlarý okumak için eklenecek servis
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
#endregion
#region Ýstekler için þartnameler yazaðýz a Ip adresinden istek için dakikada 100 request b Ip adresinden istek için dakikada 10 request mesela
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));//IP adreslerine farklý farklý þartlar atacaðýmýz yeri okumak için
#endregion

#endregion

#region Api adresi içindeki datalarý ve policy içindeki datalarý tutacaðý memorycache ekleyelim.
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();//AddSingleton 1 kere yüklensin demek. 
#endregion

#region Gelen istek sayýlarýný da tutmak gerekli
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
#endregion

#region Request sahibinin IP ve Header bilgisini okuyabilmek adýna
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
#endregion

#region ratelimit konfigürasyon için ana servisimiz 
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseIpRateLimiting();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
