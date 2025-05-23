using EmployeeRecordsManagement.Models;
using EmployeeRecordsManagement.ViewModels;

namespace EmployeeRecordsManagement.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeViewModel> GetByIdAsync(int id);
        Task<List<EmployeeViewModel>> GetAllAsync();
        Task AddAsync(EmployeeViewModel employee);
        Task UpdateAsync(EmployeeViewModel employee);
        Task DeleteAsync(int Id);
        Task<List<Department>> GetAllDepartments();
    }
}
