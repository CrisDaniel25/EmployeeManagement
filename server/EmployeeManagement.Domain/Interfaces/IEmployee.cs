using EmployeeManagement.Domain.Interfaces.Base;
using EmployeeManagement.Domain.Entities.Employees;

namespace EmployeeManagement.Domain.Interfaces
{
    public interface IEmployee : IRepository<Employee>
    {
        Employee GetEmployee(int id);
    }
}
