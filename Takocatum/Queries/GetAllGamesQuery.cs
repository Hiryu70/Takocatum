using Microsoft.AspNetCore.Mvc;

namespace Takocatum.Queries
{
    public class GetAllGames : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
