using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Domain.Entities.Authentication
{
    public class User
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
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [MaxLength(100)]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; } = string.Empty;
        public bool Status { get; set; }

        public int RolID { get; set; }

        [ForeignKey(nameof(RolID))]
        public virtual Rol Rol { get; set; } = default!;
    }
}
