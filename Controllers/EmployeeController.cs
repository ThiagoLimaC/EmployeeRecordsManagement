using EmployeeRecordsManagement.Models;
using EmployeeRecordsManagement.Repositories;
using EmployeeRecordsManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeRecordsManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        // Dependency injection
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            var employees = await _employeeRepository.GetAllAsync();

            // Search functionality
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(x => x.FirstName.Contains(searchString) 
                || x.LastName.Contains(searchString)).ToList();
            }

            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateOfBirthSortParam"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewData["IsActiveSortParam"] = sortOrder == "isactive_asc" ? "isactive_desc" : "isactive_asc";

            // Sort functionality

            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(e => e.FirstName).ToList(); // Descending order
                    break;

                case "date_asc":
                    employees = employees.OrderBy(e => e.DateOfBirth).ToList();
                    break;

                case "date_desc":
                    employees = employees.OrderByDescending(e => e.DateOfBirth).ToList();
                    break;

                case "isactive_asc":
                    employees = employees.OrderBy(e => e.IsActive).ToList();
                    break;

                case "isactive_desc":
                    employees = employees.OrderByDescending(e => e.IsActive).ToList();
                    break;

                default:
                    employees = employees.OrderBy(e => e.FirstName).ToList(); // Ascending order
                    break;
            }


            return View(employees);
        }

        // GET: Employee/Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var departments = await _employeeRepository.GetAllDepartments();

            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

            return View();
        }

        // POST: Employee/Add
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return to the form with validation errors
            }

            //Save the employee to the database
            await _employeeRepository.AddAsync(model);

            // Redirect to List all department page
            return RedirectToAction("Index", "Employee");

        }

        //GET: Employee/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // Fetch department details
            var departments = await _employeeRepository.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");
            

            // Fetch employee details
            var employee = await _employeeRepository.GetByIdAsync(id);

            return View(employee);
        }

        //GET: Employee/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee); // Return to the form with validations errors
            }

            // Update the database with modified details
            await _employeeRepository.UpdateAsync(employee);

            // Return to List all employee page
            return RedirectToAction("Index", "Employee");
        }

        //GET: Employee/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // Fetch employee details
            await _employeeRepository.DeleteAsync(id);

            // Return to List all employee page
            return RedirectToAction("Index", "Employee");
        }
    }
}
