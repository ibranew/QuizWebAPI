using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizWebAPI.Application.Abstractions.Repositories;
using QuizWebAPI.Application.Abstractions.Services;
using QuizWepAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // MediatR ilgili projeden herhangi bir class bildirilmesi ile o projede
            // handler'larını arayıp bulacaktır. assembly seviyesinde halledecektir
            services.AddMediatR(typeof(ServiceRegistration).Assembly);
        }
    }
}
