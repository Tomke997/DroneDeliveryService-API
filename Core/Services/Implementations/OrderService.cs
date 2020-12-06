using Application.Services.Interfaces;
using Entities.ApplicationEntities;
using infrastracture.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class OrderService : IService<Order>
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Task<Order> Add(Order entity)
        {
            try
            {
                return _orderRepository.Add(entity);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public Task<Order> Delete(int id)
        {
            try
            {
                return _orderRepository.Delete(id);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            try
            {
                return _orderRepository.GetAll();
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

         public Task<Order> GetById(int id)
        {
            try
            {
                return _orderRepository.GetById(id);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }

        public Task<Order> Update(int id, Order entity)
        {
            try
            {
                return _orderRepository.Update(id, entity);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message, x.InnerException);
            }
        }
    }
}
