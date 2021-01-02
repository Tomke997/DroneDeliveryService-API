using Application.Services.Interfaces;
using Entities.ApplicationEntities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using infrastracture.Repositories.Interfaces;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;
using Persistance.Repositories.Interfaces;

namespace Application.Services.Implementations
{
    public class DroneService : IDroneService<Drone>
    {
        private readonly IDroneRepository<Drone> _droneRepository;

        public DroneService(IDroneRepository<Drone> droneRepository)
        {
            _droneRepository = droneRepository;
        }

        public Task<Drone> Add(Drone entity)
        {
            try
            {
                return _droneRepository.Add(entity);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public Task<Drone> Delete(int id)
        {
            try
            {
                return _droneRepository.Delete(id);
            }
            catch(Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public Task<IEnumerable<Drone>> GetAll()
        {
            try
            {
                return _droneRepository.GetAll();
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public Task<Drone> GetById(int id)
        {
            try
            {
                return _droneRepository.GetById(id);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public Task<Drone> Update(int id, Drone entity)
        {
            try
            {
                return _droneRepository.Update(id, entity);
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
                await _droneRepository.SendMessageWithDirections(message);

                return false;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }
    }
}
