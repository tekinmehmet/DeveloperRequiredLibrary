using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region appsettings.json okumak i�in gerekli servis
builder.Services.AddOptions();
#endregion
#region Cache servis eklenmelidir.
builder.Services.AddMemoryCache();//dakikakada 100 istek yap�ls�n dedi�imiz zaman bu 100 iste�i memory de tutacak. Bu servis sayesinde.
#endregion

#region appsettings.json i�inden okuyaca�� keyleri belirleyelim.

#region appsettings.json i�indeki key de�erindeki ayarlar� okumak i�in eklenecek servis
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
#endregion
#region �stekler i�in �artnameler yaza��z a Ip adresinden istek i�in dakikada 100 request b Ip adresinden istek i�in dakikada 10 request mesela
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));//IP adreslerine farkl� farkl� �artlar ataca��m�z yeri okumak i�in
#endregion

#endregion

#region Api adresi i�indeki datalar� ve policy i�indeki datalar� tutaca�� memorycache ekleyelim.
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();//AddSingleton 1 kere y�klensin demek. 
#endregion

#region Gelen istek say�lar�n� da tutmak gerekli
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
#endregion

#region Request sahibinin IP ve Header bilgisini okuyabilmek ad�na
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
#endregion

#region ratelimit konfig�rasyon i�in ana servisimiz 
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
