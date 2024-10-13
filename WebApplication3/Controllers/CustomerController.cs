using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Repos;
using WebApplication3.Sales;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository repos;

        public CustomerController(CustomerRepository repos)
        {
            this.repos = repos;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var customers = repos.GetAll();
            try
            {
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            try
            {
                var data = repos.Create(customer);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var CustomerFind = repos.GetCustomerById(id);
                if (CustomerFind == null)
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
        public IActionResult Put(Customer customer)
        {
            try
            {
                var data = repos.Update(customer);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
    
   
