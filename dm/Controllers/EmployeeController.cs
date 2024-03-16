using dm.Data;
using dm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace dm.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext applicationDBContext;

        public EmployeeController(ApplicationDbContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        [Authorize]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddEmployee(Employees employee, IFormFile imgfile)
        {
            if (imgfile != null && imgfile.Length > 0)
            {
                var fileName = Path.GetFileName(imgfile.FileName);
                var random = new Random();
                var randomNumber = random.Next(1, 200);
                var uniqueFileName = randomNumber + fileName;
                var folderPath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/uploads");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(folderPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imgfile.CopyTo(stream);
                }

                var dbImagePath = Path.Combine("uploads", uniqueFileName);
                employee.Image = dbImagePath;

                applicationDBContext.Employees.Add(employee);
                applicationDBContext.SaveChanges();
            }

            return RedirectToAction("FetchEmployee");
        }
        [Authorize]
        public IActionResult FetchEmployee()
        {
            return View(applicationDBContext.Employees.ToList());
        }
        [Authorize]
        public IActionResult DeleteEmployee(int id)
        {
            Employees employee = applicationDBContext.Employees.Find(id);
            applicationDBContext.Employees.Remove(employee);
            applicationDBContext.SaveChanges();
            return RedirectToAction("FetchEmployee");
        }

        public IActionResult EditEmployee(int id)
        {
            return View(applicationDBContext.Employees.Find(id));
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditEmployee(Employees employee, IFormFile imgfile)
        {
            if (imgfile != null && imgfile.Length > 0)
            {
                var fileName = Path.GetFileName(imgfile.FileName);
                var random = new Random();
                var randomNumber = random.Next(1, 200);
                var uniqueFileName = randomNumber + fileName;
                var folderPath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/uploads");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(folderPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imgfile.CopyTo(stream);
                }

                var dbImagePath = Path.Combine("uploads", uniqueFileName);
                employee.Image = dbImagePath;

                applicationDBContext.Employees.Update(employee);
                applicationDBContext.SaveChanges();
            }

            return RedirectToAction("FetchEmployee");
        }

        [Authorize]
        public IActionResult delete(int id)
        {
            Employees employee = applicationDBContext.Employees.Find(id);
            applicationDBContext.Employees.Remove(employee);
            applicationDBContext.SaveChanges();
            return RedirectToAction("FetchEmployee");
        }
    }
}
