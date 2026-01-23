using Microsoft.AspNetCore.Mvc;

namespace FoodHeaven.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
