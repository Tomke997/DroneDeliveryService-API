using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Application;
using Domain;
using Domain.Models;
using Entities.ApplicationEntities;
using MongoDB.Driver;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;

namespace infrastracture
{
    public class ApplicationContext : IApplicationContext
    {
        private readonly IMqttClientOptions _clientOptions;
        private readonly IMqttClient _mqttClient;
        public ApplicationContext(IMongoDBSettings mongoSettings, IMqttBrokerSettings mqttSettings)
        {
            MongoClient client = new MongoClient(mongoSettings.ConnectionString);
            IMongoDatabase _database = client.GetDatabase(mongoSettings.DatabaseName);
            _mqttClient = new MqttFactory().CreateMqttClient();

            Drone = _database.GetCollection<Drone>(mongoSettings.DroneCollectionName);
            Order = _database.GetCollection<Order>(mongoSettings.OrderCollectionName);

            _clientOptions = createMqqClientOptions(mqttSettings);
        }

        private IMqttClientOptions createMqqClientOptions(IMqttBrokerSettings mqttSettings)
        {
            var clientId = Guid.NewGuid().ToString();

            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                .WithClientId(clientId)
                .WithCredentials(mqttSettings.MqttUsername, mqttSettings.MqttPassword)
                .WithTcpServer(mqttSettings.MqttIp, mqttSettings.MqttPort);

            return builder.Build();
        }

        private async Task<IMqttClient> ReturnConnectedMqttClient()
        {
            if (!_mqttClient.IsConnected)
            {
                await _mqttClient.ConnectAsync(_clientOptions);

                return _mqttClient;
            }

            return _mqttClient;
        }

        public IMongoCollection<Order> Order { get; set; }
        public IMongoCollection<Drone> Drone { get; set; }
        public Task<IMqttClient> MqttClient
        {
            get { return ReturnConnectedMqttClient();}

            set => throw new NotImplementedException();
        }
    }
}
