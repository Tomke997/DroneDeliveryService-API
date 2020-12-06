using Application;
using Domain;
using Domain.Models;
using Entities.ApplicationEntities;
using MongoDB.Driver;

namespace infrastracture
{
    public class ApplicationContext : IApplicationContext
    {
        public ApplicationContext(IMongoDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase _database = client.GetDatabase(settings.DatabaseName);

            Drone = _database.GetCollection<Drone>(settings.DroneCollectionName);
            Order = _database.GetCollection<Order>(settings.OrderCollectionName);
        }

        public IMongoCollection<Order> Order { get; set; }
        public IMongoCollection<Drone> Drone { get; set; }
    }
}
