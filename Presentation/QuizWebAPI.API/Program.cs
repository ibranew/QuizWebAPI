using QuizWepAPI.Persistence;
using QuizWebAPI.Application;
using QuizWebAPI.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("https://gelebek.com", "http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//JWT yapýlandýrmasý
string? securityKeyConfig = builder.Configuration["Token:SecurityKey"];
if (string.IsNullOrEmpty(securityKeyConfig))
{
    throw new Exception("Token:SecurityKey is not exist");
}
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("User", options =>
    {
        options.TokenValidationParameters = new()
        {
            // Token'ýn hangi site/origin tarafýndan kullanýlabileceðini belirten doðrulama.
            ValidateAudience = true,

            // Token'ýn kim tarafýndan oluþturulduðunu ifade eden doðrulama.
            ValidateIssuer = true,

            // Token'ýn süresinin dolup dolmadýðýný kontrol eden doðrulama.
            ValidateLifetime = true,

            // Token'ýn uygulamaya ait bir güvenlik anahtarýyla imzalanýp imzalanmadýðýný doðrulayan kontrol.
            ValidateIssuerSigningKey = true,

            // Geçerli kullanýcýlarýn token'ý kullanabileceði Audience bilgisi.
            ValidAudience = builder.Configuration["Token:Audience"],

            // Token'ý oluþturan yetkili Issuer bilgisi.
            ValidIssuer = builder.Configuration["Token:Issuer"],



            // Token'ýn imzalanmasýnda kullanýlan güvenlik anahtarý.
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKeyConfig)),

            // Token'ýn süresinin geçerliliðini kontrol eden özel bir doðrulama.
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                expires != null ? expires > DateTime.UtcNow : false,

            // JWT üzerinde "Name" claim'ine karþýlýk gelen deðeri, User.Identity.Name üzerinden alabilmek için belirlenen yapýlandýrma.
            NameClaimType = ClaimTypes.Name
        };
    });

builder.Services.AddInfrastructureServices();//Infrastructure Servisleri
builder.Services.AddPersistenceServices(builder.Configuration);//Persistence Servisleri
builder.Services.AddApplicationServices();// Application Servisleri

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();
app.MapControllers();

app.Run();
