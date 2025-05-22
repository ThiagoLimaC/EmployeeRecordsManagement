using EmployeeRecordsManagement.Models;
using EmployeeRecordsManagement.ViewModels;

namespace EmployeeRecordsManagement.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> GetByIdAsync(int id);
        Task<List<Department>> GetAllAsync();
        Task AddAsync(DepartmentViewModel department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(int Id);
    }
}
