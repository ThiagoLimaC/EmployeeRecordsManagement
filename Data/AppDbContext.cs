﻿using EmployeeRecordsManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordsManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
