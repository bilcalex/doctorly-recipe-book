using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Models;

namespace RecipeApi.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeContext _context;

        public RecipesController(RecipeContext context)
        {
            _context = context;

            // if (_context.RecipeItems.Count() == 0)
            // {
            //     _context.RecipeItems.Add(new RecipeItem 
            //     {
            //         Name = "RecipeTest",
            //         Description = "DescriptionTest",
            //         Ingredients = new List<Ingredient>(),
            //         Directions = new List<Direction>()
            //     });

            //     _context.RecipeItems.Add(new RecipeItem 
            //     {
            //         Name = "RecipeTestAgain",
            //         Description = "DescriptionTestAgain",
            //         Ingredients = new List<Ingredient>(),
            //         Directions = new List<Direction>()
            //     });
            //     _context.SaveChanges();
            // }
        }

        // GET api/recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeItem>>> GetRecipeItems()
        {
            return await _context.RecipeItems.ToListAsync();
        }


        // GET api/recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeItem>> GetRecipeItem(long id)
        {
            var recipeItem = await _context.RecipeItems.FindAsync(id);

            if (recipeItem == null)
            {
                return NotFound();
            }

            return recipeItem;
        }

        // POST: api/recipes
        [HttpPost]
        public async Task<ActionResult<RecipeItem>> PostRecipeItem(RecipeItem item)
        {
            _context.RecipeItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipeItem), new { id = item.Id }, item);
        }
    }
}
