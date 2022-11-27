using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Domain.Entities.Employees
{
    public class Position
    {
        public int ID { get; set; }
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(150)]
        public string Description { get; set; } = string.Empty;

        public int DepartmentID { get; set; }

        [ForeignKey(nameof(DepartmentID))]
        public virtual Department Department { get; set; } = default!;
        public ICollection<Employee> Employees { get; set; } = default!;
    }
}
