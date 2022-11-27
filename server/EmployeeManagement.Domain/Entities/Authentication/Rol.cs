using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities.Authentication
{
    public class Rol
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = default!; 
    }
}
