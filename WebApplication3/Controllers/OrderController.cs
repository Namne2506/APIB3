using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Repos;
using WebApplication3.Sales;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository repos;

        public OrderController(OrderRepository repos)
        {
            this.repos = repos;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var orders = repos.GetAll();
            try
            {
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Order order)
        {
            try
            {
                var data = repos.Create(order);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var order = repos.GetOrderById(id);
                if (order == null)
                {
                    return NotFound();
                }

                var deleted = repos.Delete(id);
                if (!deleted)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Order order)
        {
            try
            {
                var data = repos.Update(order);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
