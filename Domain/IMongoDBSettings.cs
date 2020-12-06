using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IMongoDBSettings
    {
        string DroneCollectionName { get; set; }
        string OrderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
