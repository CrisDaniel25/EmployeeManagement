namespace EmployeeManagement.API.Dtos.Employees
{
    public class EmployeeDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;        
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public int? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool Status { get; set; }
        public bool? IsPartTime { get; set; }

        public int? DepartmentID { get; set; }
        public int? PositionID { get; set; }
    }
}
