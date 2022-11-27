using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Infrastructure.Repositories.Base;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class PositionRepository : Repository<Position>, IPosition
    {
        public PositionRepository(DataContext context) : base(context) { }

        public List<Position> GetPositions()
        {
            try
            {
                var positions = _context.Positions.Include(x => x.Department).ToList();
                return positions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
