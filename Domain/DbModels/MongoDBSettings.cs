using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string DroneCollectionName { get; set; }
        public string OrderCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
