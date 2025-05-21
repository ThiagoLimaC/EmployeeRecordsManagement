﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeRecordsManagement.ViewModels
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; } //Primary key

        [Required(ErrorMessage = "Department name is required.")]
        public string Name { get; set; }
    }
}
