using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Domain.Entities.Employees
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }        
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;        
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;        
        [MaxLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; } = string.Empty;
        public int? Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool Status { get; set; }
        public bool? IsPartTime { get; set; }

        public int PositionID { get; set; }
        
        [ForeignKey(nameof(PositionID))]
        public virtual Position Position { get; set; } = default!;
    }
}
