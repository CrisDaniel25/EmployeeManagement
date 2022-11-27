using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Domain.Interfaces.Base;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Infrastructure.Repositories.Base;
using EmployeeManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployee
    {
        public EmployeeRepository(DataContext context) : base(context) { }

        public Employee GetEmployee(int id)
        {
            try
            {
                var employee = _context.Employees
                    .Where(x => x.ID == id)
                    .Include(x => x.Position)
                    .FirstOrDefault();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
