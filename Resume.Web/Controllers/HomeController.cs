using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
