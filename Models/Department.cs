namespace EmployeeRecordsManagement.Models
{
    public class Department
    { 
        public int DepartmentId { get; set; } //Primary key
        public string Name { get; set; } 

        // Relationship with Employees
        public ICollection<Employee> Employees { get; set; } // Collection
    }
}
