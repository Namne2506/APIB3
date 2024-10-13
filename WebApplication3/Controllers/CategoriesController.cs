using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Repos;
using WebApplication3.Sales;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesRepository repos;

        public CategoriesController(CategoriesRepository repos)
        {
            this.repos = repos;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var categories = repos.GetAll();
            try
            {
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Categories categories)
        {
            try
            {
                var data = repos.create(categories);
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
                var categories = repos.GetCategoriesById(id);
                if (categories == null)
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
        public IActionResult Put(Categories categories)
        {
            try
            {
                var data = repos.Update(categories);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
