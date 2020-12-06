using Application;
using infrastracture.Repositories.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Implementation
{
    class DroneRepository<Drone> : IRepository<Drone>
    {
        public readonly IApplicationDbContext _context;

        public DroneRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Drone> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Drone>> GetAll()
        {
        }

        public async Task<Drone> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Drone> Update(Drone entity)
        {
            throw new NotImplementedException();
        }
    }
}
