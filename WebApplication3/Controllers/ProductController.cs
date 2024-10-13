using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Repos;
using WebApplication3.Sales;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository repos;

        public ProductController(ProductRepository repos)
        {
            this.repos = repos;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var products = repos.GetAll();
            try
            {
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                var data = repos.create(product);
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
                var productFind = repos.GetProductById(id);
                if (productFind == null)
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
        public IActionResult Put(Product product)
        {
            try
            {
                var data = repos.Update(product);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
