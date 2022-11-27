using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities.Employees
{
    public class Department
    {
        public int ID { get; set; }
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(150)]
        public string Description { get; set; } = string.Empty;

        public ICollection<Position> Positions { get; set; } = default!;
    }
}
