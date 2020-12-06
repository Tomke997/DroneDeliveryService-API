using Application;
using Domain;
using Entities.ApplicationEntities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastracture
{
    public class ApplicationContext : IApplicationDbContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly IMongoCollection<Drone> _droneCollection = null;
        private readonly IMongoCollection<Order> _orderCollection = null;


        public ApplicationContext(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);

            _droneCollection = _database.GetCollection<Drone>(settings.DroneCollectionName);
            _orderCollection = _database.GetCollection<Order>(settings.OrderCollectionName);
        } 
    }
}
