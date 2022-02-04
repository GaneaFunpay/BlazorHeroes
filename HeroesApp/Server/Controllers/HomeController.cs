using Microsoft.AspNetCore.Mvc;

namespace HeroesApp.Server.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
