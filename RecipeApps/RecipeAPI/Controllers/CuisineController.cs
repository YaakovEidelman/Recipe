using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<bizCuisine> c = new bizCuisine().GetList();
            return Ok(c);
        }
    }
}
