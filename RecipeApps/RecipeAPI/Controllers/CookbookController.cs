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
            return Ok(new bizCookbook().GetList());
        }

        [HttpGet("query")]
        public IActionResult GetById(int id, int all)
        {
            return Ok(new bizCookbook().Search(id, all));
        }
    }
}
