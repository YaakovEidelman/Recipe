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
            return Ok(new bizRecipe().GetList());
        }

        [HttpGet("query")]
        public IActionResult GetById(int id)
        {
            return Ok(new bizRecipe().Search(id, ""));
        }
    }
}
