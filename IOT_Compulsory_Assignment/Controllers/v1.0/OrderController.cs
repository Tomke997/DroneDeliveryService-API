using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Entities.ApplicationEntities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class OrderController : BaseApiController
    {
        private readonly IService<Order> _orderService;

        public OrderController(IService<Order> orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Creates a new Order entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Order entity)
        {
            try
            {
                await _orderService.Add(entity);
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        /// <summary>
        /// Gets all Orders.
        /// </summary>
        /// <returns>List of all Drones</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Order> listOfAllOrders = await _orderService.GetAll();
                return Ok(listOfAllOrders);
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        /// <summary>
        /// Gets Order entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Drone entity</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Order selectedOrder = await _orderService.GetById(id);

                if (selectedOrder == null)
                {
                    return NotFound("Given order could not be found");
                }

                return Ok(selectedOrder);
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        /// <summary>
        /// Deletes Order entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Order deletedOrder = await _orderService.Delete(id);

                if (deletedOrder == null)
                {
                    return BadRequest("Given order could not be deleted");
                }

                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        /// <summary>
        /// Updates the Order entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Order entity)
        {
            try
            {
                if (id != entity.OrderId)
                {
                    return NotFound("Given order could not be found");
                }

                Order updatedOrder = await _orderService.Update(id, entity);

                if (updatedOrder == null)
                {
                    return BadRequest("Given order could not be updated");
                }

                return Ok(updatedOrder);
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }
    }
}
