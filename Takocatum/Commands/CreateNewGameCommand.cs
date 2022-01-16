using Microsoft.AspNetCore.Mvc;

namespace Takocatum.Commands
{
    public class CreateNewGame : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
