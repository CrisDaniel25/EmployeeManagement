namespace EmployeeManagement.Domain.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployee Employee { get; }
        IDepartment Department { get; }
        IPosition Position { get; }
    }
}
