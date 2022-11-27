using System.Linq.Expressions;

namespace EmployeeManagement.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<IReadOnlyCollection<T>> Find(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<IReadOnlyCollection<T>> AddRange(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<IReadOnlyCollection<T>> UpdateRange(IEnumerable<T> entities);
        Task Delete(T entity);
        Task DeleteRange(IEnumerable<T> entities);
    }
}
