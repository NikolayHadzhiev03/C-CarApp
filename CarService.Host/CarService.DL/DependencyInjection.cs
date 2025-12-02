using CarService.DL.Interfaces;
using CarService.DL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.DL
{
    public static class DependencyInjection
    {
        public static IServiceCollection 
            AddDataLayer(this IServiceCollection services)
        {
            // Register data layer services here
            services.AddSingleton<ICarRepository, CarLocalRepository>();
            services.AddSingleton<ICustomerRepository, CustomerLocalRepository>();

            return services;
        }
    }
}
