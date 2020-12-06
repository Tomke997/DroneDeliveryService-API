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
    public class OrderRepository : IRepository<Order>
    {
        public readonly IApplicationContext _context;

        public OrderRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Order> Add(Order entity)
        {
            try
            {
                await _context.Order.InsertOneAsync(entity);
                return entity;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public async Task<Order> Delete(int id)
        {
            try
            {
                return await _context.Order.FindOneAndDeleteAsync(o => o.OrderId == id);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            try
            {
                return await _context.Order.Find(_ => true).ToListAsync();
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public async Task<Order> GetById(int id)
        {
            try
            {
                return await _context.Order.Find(o => o.OrderId == id).FirstAsync();
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public async Task<Order> Update(int id, Order entity)
        {
            try
            {
                await _context.Order.ReplaceOneAsync(o => o.OrderId == id, entity);
                return entity;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }
    }
}
