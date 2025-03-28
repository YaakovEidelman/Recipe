using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<bizStaff> s = new bizStaff().GetList();
            return Ok(s);
        }
    }
}
