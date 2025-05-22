using EmployeeRecordsManagement.Data;
using EmployeeRecordsManagement.Models;
using EmployeeRecordsManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordsManagement.Repositories
{
    public class DepartamentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartamentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Department> GetByIdAsync(int id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }
        public async Task<List<Department>> GetAllAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public async Task AddAsync(DepartmentViewModel department)
        {
            var newDepartment = new Department()
            {
                Name = department.Name
            };

            await _dbContext.Departments.AddAsync(newDepartment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            Department department = await _dbContext.Departments.FindAsync(Id);
            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Department departmentUpdated)
        {
            var department = await _dbContext.Departments.FindAsync(departmentUpdated.DepartmentId);
            department.Name = departmentUpdated.Name;
            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
        }
    }
}
