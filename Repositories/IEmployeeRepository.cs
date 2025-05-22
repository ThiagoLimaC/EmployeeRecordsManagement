using EmployeeRecordsManagement.Models;
using EmployeeRecordsManagement.ViewModels;

namespace EmployeeRecordsManagement.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
        Task AddAsync(EmployeeViewModel employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int Id);
        Task<List<Department>> GetAllDepartments();
    }
}
