using EmployeeRecordsManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecordsManagement.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: Employee/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Employee/Add
        [HttpPost]
        public IActionResult Add(EmployeeViewModel model)
        {
            return View();
        }
    }
}
