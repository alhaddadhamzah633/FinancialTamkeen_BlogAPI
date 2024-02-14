using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "The First Name is required",AllowEmptyStrings =false)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name is required", AllowEmptyStrings = false)]
        public string? LastName { get; set; }

        public string? Department { get; set; }

        [Required(ErrorMessage = "The Salary is required", AllowEmptyStrings = false)]
        public decimal salary { get; set; }
    }
}
