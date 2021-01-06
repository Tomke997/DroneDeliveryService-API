using Application;
using Entities.ApplicationEntities;
using infrastracture.Repositories.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using Persistance.Repositories.Interfaces;

namespace Persistance.Repositories.Implementation
{
    [BsonIgnoreExtraElements]
    class DroneRepository : IDroneRepository<Drone>
    {
        public readonly IApplicationContext _context;

        public DroneRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Drone> Add(Drone entity)
        {
            try
            {
                await _context.Drone.InsertOneAsync(entity);
                return entity;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public async Task<Drone> Delete(int id)
        {
            try
            {
                return await _context.Drone.FindOneAndDeleteAsync(d => d.DroneId == id);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public async Task<IEnumerable<Drone>> GetAll()
        {
            try
            {
                return await _context.Drone.Find(_ => true).ToListAsync();
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }           
        }

        public async Task<Drone> GetById(int id)
        {
            try
            {
                return await _context.Drone.Find(d => d.DroneId == id).FirstAsync();
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public async Task<Drone> Update(int id, Drone entity)
        {
            try
            {
                await _context.Drone.ReplaceOneAsync(d => d.DroneId == id, entity);
                return entity;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public async Task<bool> SendMessageWithDirections(string message)
        {
            try
            {
                var mqttClient = await _context.MqttClient;

                    await mqttClient.PublishAsync(new MqttApplicationMessageBuilder()
                        .WithTopic("drone/test")
                        .WithPayload(message)
                        .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.ExactlyOnce)
                        .WithRetainFlag(true)
                        .Build());

                    return true;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public async Task<bool> SendMessageWithDirectionsRPi(string message)
        {
            try
            {
                var mqttClient = await _context.MqttClient;

                await mqttClient.PublishAsync(new MqttApplicationMessageBuilder()
                    .WithTopic("topic/manual_flight")
                    .WithPayload(message)
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.ExactlyOnce)
                    .WithRetainFlag(false)
                    .Build());

                return true;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public async Task<bool> SendMessageWithFlyToLatLongRPi(string message)
        {
            try
            {
                var mqttClient = await _context.MqttClient;

                await mqttClient.PublishAsync(new MqttApplicationMessageBuilder()
                    .WithTopic("topic/fly_to")
                    .WithPayload(message)
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.ExactlyOnce)
                    .WithRetainFlag(false)
                    .Build());

                return true;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }
    }
}
