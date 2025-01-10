using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using QuizWepAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using QuizWepAPI.Persistence.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using QuizWebAPI.Application.Abstractions.Repositories;
using QuizWepAPI.Persistence.Concretes.Repositories;
using QuizWebAPI.Application.Abstractions.Services;
using QuizWepAPI.Persistence.Concretes.Services;
using QuizWebAPI.Application.Abstractions.Services.EntityServices;


namespace QuizWepAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // appsettings.json'dan bağlantı dizesini al
            var connectionString = configuration["Connection:DefaultConnection"];

            // DbContext ile SQL Server bağlantısı
            services.AddDbContext<QuizWebAPIDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Identity ayar
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
            })
            .AddEntityFrameworkStores<QuizWebAPIDbContext>()
            .AddDefaultTokenProviders();

            //repositories
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
          

            //services
            services.AddScoped<IQuizService,QuizService>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<IAnswersService,AnswersService>();
            services.AddScoped<IQuestionService,QuestionService>();
        }
        }
}
