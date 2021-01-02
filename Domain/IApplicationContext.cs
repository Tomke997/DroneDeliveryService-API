using Entities.ApplicationEntities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MQTTnet.Client;

namespace Application
{
    public interface IApplicationContext
    {
        IMongoCollection<Order> Order { get; set; }

        IMongoCollection<Drone> Drone { get; set; }

        Task<IMqttClient> MqttClient { get; set; }
    }
}
