using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServicesExtension).Assembly;
            services.AddAutoMapper(assembly);
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
