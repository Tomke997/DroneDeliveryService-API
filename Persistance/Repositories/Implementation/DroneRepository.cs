using Application;
using Entities.ApplicationEntities;
using infrastracture.Repositories.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Repositories.Implementation
{
    [BsonIgnoreExtraElements]
    class DroneRepository : IRepository<Drone>
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
    }
}
