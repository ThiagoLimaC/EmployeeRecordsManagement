using EmployeeRecordsManagement.Models;
using EmployeeRecordsManagement.ViewModels;

namespace EmployeeRecordsManagement.Repositories
{
    public interface IDepartmentRepository
    {
        Task<DepartmentViewModel> GetByIdAsync(int id);
        IQueryable<DepartmentViewModel> GetAllAsync();
        Task AddAsync(DepartmentViewModel department);
        Task UpdateAsync(DepartmentViewModel department);
        Task DeleteAsync(int Id);
    }
}
