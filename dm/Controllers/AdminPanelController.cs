using Microsoft.AspNetCore.Mvc;

namespace dm.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
