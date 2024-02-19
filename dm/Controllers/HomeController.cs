using dm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }

        public IActionResult inbound()
        {
            return View();
        }

        public IActionResult technicalsupport()
        {

            return View();
        }

		public IActionResult CustomerService()
		{

			return View();
		}

		public IActionResult outbound()
		{
			return View();
		}
		public IActionResult HR()
		{
			return View();
		}
		public IActionResult Administration()
		{
			return View();
		}
		public IActionResult service()
		{
			return View();
		}
		public IActionResult training()
		{
			return View();
		}
		public IActionResult internetsecurity()
		{
			return View();
		}
		public IActionResult Auditors()
		{
			return View();
		}

		public IActionResult telemarketing()
		{
			return View();
		}
		public IActionResult Seo()
		{
			return View();
		}
		public IActionResult Digitalmark()
		{
			return View();
		}
		public IActionResult webdevelopment()
		{
			return View();
		}

		public IActionResult portfolio()
		{
			return View();
		}
	
		public IActionResult team()
		{
			return View();
		}
		public IActionResult about()
		{
			return View();
		}
		public IActionResult contact()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}