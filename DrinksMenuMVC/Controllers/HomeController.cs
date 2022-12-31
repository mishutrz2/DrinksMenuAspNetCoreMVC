using Microsoft.AspNetCore.Mvc;

namespace DrinksMenuMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
