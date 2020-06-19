using Microsoft.AspNetCore.Mvc;
using spoons.Data;

namespace spoons.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class HealthCheckController : ControllerBase 
    {
        private CoreContext _context;

        public HealthCheckController (CoreContext context)
        {
            _context = context;
        }


        public string healthCheck ()
        {
            return "Health";
        }
    }
}