using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Domain.Interfaces.Base;
using EmployeeManagement.Infrastructure.Data;

namespace EmployeeManagement.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IEmployee Employee { get; }
        public IDepartment Department { get; }
        public IPosition Position { get; }

        public UnitOfWork(DataContext context, IEmployee employee, IDepartment department, IPosition position)
        {
            _context = context;
            Employee = employee;
            Department = department;
            Position = position;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
