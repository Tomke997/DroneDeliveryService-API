using Entities.ApplicationEntities;
using infrastracture;
using infrastracture.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public static class DependencyInjection
    {
        public static void AddPersistance(this IServiceCollection services)
        {
            //Dependency injection for drone repository
            services.AddScoped<IRepository<Drone>, DroneRepository>();

            //Dependency injection for drone repository
            services.AddScoped<IRepository<Order>, OrderRepository>();

            //Dependency injection for order service
            services.AddSingleton<ApplicationContext>();
        }
    }
}
