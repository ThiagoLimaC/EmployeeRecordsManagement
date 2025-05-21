using EmployeeRecordsManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecordsManagement.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        // POST: Employee/Add
        [HttpPost]
        public IActionResult Add(DepartmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return to the form with validation errors
            }

            return View();
        }
    }
}
