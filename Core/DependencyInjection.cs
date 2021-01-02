using Application.Services.Implementations;
using Application.Services.Interfaces;
using Entities.ApplicationEntities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //Dependency injection for drone service
            services.AddScoped<IDroneService<Drone>, DroneService>();

            //Dependency injection for order service
            services.AddScoped<IService<Order>, OrderService>();
        }
    }
}
