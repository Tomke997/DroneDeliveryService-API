using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Entities.ApplicationEntities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class DroneController : BaseApiController
    {
        private readonly IDroneService<Drone> _droneService;

        public DroneController(IDroneService<Drone> droneService)
        {
            _droneService = droneService;
        }

        /// <summary>
        /// Creates a new Drone entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Drone entity)
        {
            try
            {
                await _droneService.Add(entity);
                return Ok();
            }
            catch(Exception x)
            {
                return BadRequest(x); 
            }
        }

        /// <summary>
        /// Gets all Drones.
        /// </summary>
        /// <returns>List of all Drones</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Drone> listOfAllDrones = await _droneService.GetAll();
                return Ok(listOfAllDrones);
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        /// <summary>
        /// Gets Drone entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Drone entity</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Drone selectedDrone = await _droneService.GetById(id);

                if(selectedDrone == null)
                {
                    return NotFound("Given drone could not be found");
                } 

                return Ok(selectedDrone);
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        /// <summary>
        /// Deletes Drone entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Drone deletedDrone = await _droneService.Delete(id);

                if (deletedDrone == null)
                {
                    return BadRequest("Given drone could not be deleted");
                }

                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        /// <summary>
        /// Updates the Drone entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Drone entity)
        {
            try
            {
                if (id != entity.DroneId)
                {
                    return NotFound("Given drone could not be found");
                }

                Drone updatedDrone = await _droneService.Update(id, entity);

                if (updatedDrone == null)
                {
                    return BadRequest("Given drone could not be updated");
                }

                return Ok(updatedDrone);
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        /// <summary>
        /// Send direction message to the drone.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost("SendMessageToDrone")]
        public async Task<IActionResult> SendMessageToDrone(string message)
        {
            try
            {
                await _droneService.SendMessageWithDirections(message);
                return Ok("Message Sent");
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }
    }
}
