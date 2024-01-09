using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Aplication.Interfaces;
using POS.Aplication.Services;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Infraestructure.Persistences.Repositories;
using System.Reflection;

namespace POS.Aplication.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionAplicacion(this IServiceCollection services, IConfiguration configuration) {
            services.AddSingleton(configuration);
            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICategoryApplication, CategoryApplication>();

            return services;
        }
    }
}
