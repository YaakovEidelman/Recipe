using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookbookController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var b = new bizCookbook()
                .GetList()
                .Select(c => c.GetType()
                    .GetProperties()
                    .Where(prop => prop.GetValue(c) != null)
                    .ToDictionary(p => p.Name, p => p.GetValue(c))
                ).ToList();
            
            return Ok(b);
        }

        [HttpGet("query")]
        public IActionResult GetById(int id)
        {
            var b = new bizCookbook()
                .Search(id, 0)
                .Select(c => c.GetType()
                    .GetProperties()
                    .Where(prop => prop.GetValue(c) != null)
                    .ToDictionary(p => p.Name, p => p.GetValue(c))
                ).ToList();
            return Ok(b);
        }
    }
}
