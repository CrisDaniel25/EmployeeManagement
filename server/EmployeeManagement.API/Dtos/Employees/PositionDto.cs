namespace EmployeeManagement.API.Dtos.Employees
{
    public class PositionDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DepartmentID { get; set; }
    }
}
