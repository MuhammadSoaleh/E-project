using Azure;
using dm.Data;
using dm.Models;
using Microsoft.AspNetCore.Mvc;

namespace dm.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext applicationDBContext;

        public ServiceController(ApplicationDbContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Services addService)
        {
            var service = new Services
            {
                Heading = addService.Heading,
                About = addService.About,
            };
            applicationDBContext.Services.Add(addService);
            applicationDBContext.SaveChanges();
            return View();
        }
        public IActionResult FetchServices()
        {
            return View(applicationDBContext.Services.ToList());
        }
        public IActionResult deleteService(int id)
        {
            Services Service = applicationDBContext.Services.Find(id);
            applicationDBContext.Services.Remove(Service);
            applicationDBContext.SaveChanges();
            return RedirectToAction("FetchServices");
        }

    }
}
