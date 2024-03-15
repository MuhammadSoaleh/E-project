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
        public IActionResult AddServices()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddServices(Services addService)
        {
            var service = new Services
            {
                Heading = addService.Heading,
                About = addService.About,
                Content = addService.Content
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
        public IActionResult EditServices(int id)
        {

            return View(applicationDBContext.Services.Find(id));
        }
        [HttpPost]
        public IActionResult EditServices(Services addService)
        {

            applicationDBContext.Services.Update(addService);
            applicationDBContext.SaveChanges();
            return RedirectToAction("FetchServices");
        }

        public IActionResult delete(int id)
        {
            Services addService = applicationDBContext.Services.Find(id);
            applicationDBContext.Services.Remove(addService);
            applicationDBContext.SaveChanges();
            return RedirectToAction("FetchServices");
        }
    }
}
