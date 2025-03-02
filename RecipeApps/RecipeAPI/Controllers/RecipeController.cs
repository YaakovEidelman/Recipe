using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;
using System.Data;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var b = new bizRecipe()
                .GetList(false, 1)
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
            return Ok(new bizRecipe().Search(id, ""));
        }
    }
}
