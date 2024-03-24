using Microsoft.AspNetCore.Mvc;

namespace BulkyWebMVC.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
