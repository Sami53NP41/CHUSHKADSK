using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
