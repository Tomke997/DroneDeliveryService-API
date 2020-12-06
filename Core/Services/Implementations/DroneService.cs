using Application.Services.Interfaces;
using Entities.ApplicationEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using infrastracture.Repositories.Interfaces;

namespace Application.Services.Implementations
{
    public class DroneService : IService<Drone>
    {
        private readonly IRepository<Drone> _droneRepository;

        public DroneService(IRepository<Drone> droneRepository)
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
    }
}
