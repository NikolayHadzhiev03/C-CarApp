using System;
using CarService.BL.Interfaces;
using CarService.BL.Services;
using CarService.Models.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CarService.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            // Register business layer services
            services.AddSingleton<ICarCrudService, CarCrudService>();
            services.AddSingleton<ICustomerCrudService, CustomerCrudService>();

            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configs)
        {
            // Bind options from configuration
            services.Configure<MongoDbConfiguration>(configs.GetSection("MongoDbConfiguration"));

            // Create and register Mongo client + database for direct injection
            var mongoConfig = configs.GetSection("MongoDbConfiguration").Get<MongoDbConfiguration>()
                              ?? throw new InvalidOperationException("Missing MongoDbConfiguration section in configuration.");

            var mongoClient = new MongoClient(mongoConfig.ConnectionString);
            services.AddSingleton<IMongoClient>(mongoClient);
            services.AddSingleton(sp => mongoClient.GetDatabase(mongoConfig.DatabaseName));

            return services;
        }
    }
}
