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

        [HttpGet("cookbook/{cookbookname}")]
        public IActionResult GetRecipes(string cookbookname)
        {
            return Ok(new bizRecipe().Search(0, "", false, cookbookname, 1));
        }
        [HttpGet("cuisine/{cuisineId}")]
        public IActionResult GetByCuisine(int cuisineId)
        {
            List<bizRecipe> c = new bizRecipe().GetList(false, 1, cuisineId);
            return Ok(c);
        }

        //[FromForm]  

        [HttpPost("upsert")]
        public IActionResult Post(bizRecipe r)
        {
            try
            {
                r.Save();
                r.ErrorMessage = "Saved";
                return Ok(r);
            }
            catch (Exception ex)
            {
                r.ErrorMessage = ex.Message;
                return BadRequest(r);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int recipeid)
        {
            //bizRecipe r = new bizRecipe().Search(recipeid, "")[0];
            try
            {
                bizRecipe r = new bizRecipe();
                r.Delete(recipeid);
                r.ErrorMessage = "Deleted";
                return Ok(r);
            }
            catch (Exception ex)
            {
                bizRecipe r = new();
                r.ErrorMessage = ex.Message;
                return BadRequest(r);
            }
        }
    }
}
