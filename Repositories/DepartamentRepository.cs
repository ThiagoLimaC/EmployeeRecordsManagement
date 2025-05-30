﻿using EmployeeRecordsManagement.Data;
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
        public async Task<DepartmentViewModel> GetByIdAsync(int id)
        {
            var department = await _dbContext.Departments.FindAsync(id);

            var departmentViewModel = new DepartmentViewModel()
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name
            };

            return departmentViewModel;
        }
        public IQueryable<DepartmentViewModel> GetAllAsync()
        {
            var departments = _dbContext.Departments
            // The select is used for project the consult SQL, without execute 
            // Recomended for aplication of filters
            .Select(d => new DepartmentViewModel()
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name
            });

            return departments;
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

        public async Task UpdateAsync(DepartmentViewModel departmentUpdated)
        {
            var department = await _dbContext.Departments.FindAsync(departmentUpdated.DepartmentId);
            department.Name = departmentUpdated.Name;
            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
        }
    }
}
