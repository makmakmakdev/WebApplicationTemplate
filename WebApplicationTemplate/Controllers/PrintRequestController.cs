using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTemplate.Controllers
{
    public class PrintRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
