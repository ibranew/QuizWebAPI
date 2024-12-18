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

//JWT yap�land�rmas�
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
            // Token'�n hangi site/origin taraf�ndan kullan�labilece�ini belirten do�rulama.
            ValidateAudience = true,

            // Token'�n kim taraf�ndan olu�turuldu�unu ifade eden do�rulama.
            ValidateIssuer = true,

            // Token'�n s�resinin dolup dolmad���n� kontrol eden do�rulama.
            ValidateLifetime = true,

            // Token'�n uygulamaya ait bir g�venlik anahtar�yla imzalan�p imzalanmad���n� do�rulayan kontrol.
            ValidateIssuerSigningKey = true,

            // Ge�erli kullan�c�lar�n token'� kullanabilece�i Audience bilgisi.
            ValidAudience = builder.Configuration["Token:Audience"],

            // Token'� olu�turan yetkili Issuer bilgisi.
            ValidIssuer = builder.Configuration["Token:Issuer"],



            // Token'�n imzalanmas�nda kullan�lan g�venlik anahtar�.
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKeyConfig)),

            // Token'�n s�resinin ge�erlili�ini kontrol eden �zel bir do�rulama.
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                expires != null ? expires > DateTime.UtcNow : false,

            // JWT �zerinde "Name" claim'ine kar��l�k gelen de�eri, User.Identity.Name �zerinden alabilmek i�in belirlenen yap�land�rma.
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
