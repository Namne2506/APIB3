using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Repos;
using WebApplication3.Sales;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailsRepository repos;

        public OrderDetailsController(OrderDetailsRepository repos)
        {
            this.repos = repos;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var AorderDetails = repos.GetAll();
            try
            {
                return Ok(AorderDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(OrderDetails orderDetails)
        {
            try
            {
                var data = repos.create(orderDetails);
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
                var orderDetails = repos.GetOrderDetailsById(id);
                if (orderDetails == null)
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
        public IActionResult Put(OrderDetails orderDetails)
        {
            try
            {
                var data = repos.Update(orderDetails);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
