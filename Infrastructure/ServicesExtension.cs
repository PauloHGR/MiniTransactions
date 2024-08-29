using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServicesExtension
    {
        public static IServiceCollection ConfigurePersistenceApp(this IServiceCollection services,
            IConfiguration configuration)
        {
            var _getConnectionString = configuration.GetConnectionString("connSQLSERVER");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_getConnectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
