using Microsoft.AspNetCore.Mvc;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("/KosarKapcsolat")]
    public class KosarKapcsolatController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
