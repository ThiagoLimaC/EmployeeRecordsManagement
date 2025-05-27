using EmployeeRecordsManagement.Models;
using EmployeeRecordsManagement.Repositories;
using EmployeeRecordsManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecordsManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            var departments = await _departmentRepository.GetAllAsync();

            // Search functionality
            if (!String.IsNullOrEmpty(searchString))
            {
                departments = departments.Where(x => x.Name.Contains(searchString)).ToList();
            }


            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            //Sort functionality

            switch (sortOrder)
            {
                case "name_desc":
                    departments = departments.OrderByDescending(d => d.Name).ToList();
                    break;

                default:
                    departments = departments.OrderBy(d => d.Name).ToList();
                    break;
            }


            return View(departments);
        }

        // GET : Departments/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Employee/Add
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return to the form with validation errors
            }

            // Insert data to the database
            await _departmentRepository.AddAsync(model);

            return RedirectToAction("Index", "Department");
        }

        // GET: Department/edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // Fetch department details 
            var department = await _departmentRepository.GetByIdAsync(id);

            return View(department);
        }

        // Department/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentViewModel department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            await _departmentRepository.UpdateAsync(department);

            return RedirectToAction("Index", "Department");
        }

        // Department/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // Fetch department details 
            await _departmentRepository.DeleteAsync(id);

            return RedirectToAction("Index", "Department");
        }
    }
}
