using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Repositories.Base;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartment
    {
        public DepartmentRepository(DataContext context) : base(context) { }
    }
}
