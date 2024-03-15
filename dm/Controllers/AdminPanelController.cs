using Microsoft.AspNetCore.Mvc;

namespace dm.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult users_profile()
		{
			return View();
		}
		public IActionResult pages_faq()
		{
			return View();
		}
		public IActionResult pages_contact()
		{
			return View();
		}
		public IActionResult pages_login()
		{
			return View();
		}
		public IActionResult pages_error_404()
		{
			return View();
		}
	}
}
