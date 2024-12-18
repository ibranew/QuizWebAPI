using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizWebAPI.Application.Abstractions.Handlers;
using QuizWebAPI.Application.Abstractions.Repositories;
using QuizWebAPI.Application.Abstractions.Services;
using QuizWebAPI.Infrastructure.Concretes.Handlers;
using QuizWepAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler,TokenHandler>();
        }
    }
}
