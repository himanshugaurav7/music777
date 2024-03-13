using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicHub.Model.DTO;
using MusicHub.Data;
using MusicHub.Repository.IRepository;
using MusicHub.Model;
using Microsoft.AspNetCore.Authorization;

namespace MusicHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _contextOrder;
        public OrderController(IOrderRepository contextOrder)
        {
            _contextOrder = contextOrder;
        }

        [HttpGet]
        [ProducesResponseType(200)]         
        public async Task<IActionResult> GetOrder()
        {
            var order = await _contextOrder.GetAll();
            return Ok(order);

        }
        [HttpGet("{id}", Name = "GetOrder")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetOrder(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var order = await _contextOrder.Get(u => u.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);

        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                await _contextOrder.Create(order);
                await _contextOrder.Save();
                return Ok(order);
            }

            return BadRequest(ModelState);

        }
        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var order = await _contextOrder.Get(u => u.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            await _contextOrder.Remove(order);
            await _contextOrder.Save();
            return NoContent();

        }
        [HttpPut("{id}", Name = "UpdateOrder")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            var existingOrder = await _contextOrder.Get(u => u.Id == id);
            if (id != order.Id || order == null)
            {
                return BadRequest(ModelState);
            }
            await _contextOrder.Update(existingOrder);
            await _contextOrder.Save();
            return Ok(order);

        }

    }
}
