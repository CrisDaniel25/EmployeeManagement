using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Interfaces.Base;

namespace EmployeeManagement.Domain.Interfaces
{
    public interface IPosition : IRepository<Position>
    {
        List<Position> GetPositions();
    } 
}
