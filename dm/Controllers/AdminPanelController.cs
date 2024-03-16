using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dm.Controllers
{
    public class AdminPanelController : Controller
	{
		[Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult users_profile()
		{
			return View();
		}
        [Authorize]
        public IActionResult pages_faq()
		{
			return View();
		}
        [Authorize]
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
