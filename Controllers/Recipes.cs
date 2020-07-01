using Microsoft.AspNetCore.Mvc;

using spoons.Data;

namespace spoons.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class RecipesController : ControllerBase
    {
        private CoreContext _context;
        public RecipesController (CoreContext context)
        {
            _context = context;
        }
    }

    // [HttpPost ("addRecipe")]
    // [AllowAnonymous]
    // public Recipe newRecipe( )
    // {
        
    // }
}