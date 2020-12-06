using Entities.ApplicationEntities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Application
{
    public interface IApplicationContext
    {
        IMongoCollection<Order> Order { get; set; }

        IMongoCollection<Drone> Drone { get; set; }
    }
}
