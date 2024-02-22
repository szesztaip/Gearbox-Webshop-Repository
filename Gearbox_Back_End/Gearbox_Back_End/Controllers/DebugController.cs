using Microsoft.AspNetCore.Mvc;

namespace Gearbox_Back_End.Controllers
{
    public class DebugController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
