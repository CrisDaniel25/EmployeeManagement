using System.Linq.Expressions;
using EmployeeManagement.Domain.Interfaces.Base;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories.Base
{
    public class Repository <T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;

        public Repository(DataContext context) => _context = context;

        public async Task<IReadOnlyList<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Add() Method Repository: {ex.Message}");
                throw ex;
            }
        }

        public async Task<IReadOnlyCollection<T>> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Find() Method Repository: {ex.Message}");
                throw ex;
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                #pragma warning disable CS8603 // Possible null reference return.
                return await _context.Set<T>().FindAsync(id);
                #pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetById() Method Repository: {ex.Message}");
                throw ex;
            }
        }

        public async Task<T> Add(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Add() Method Repository: {ex.Message}");
                throw ex;
            }
        }

        public async Task<IReadOnlyCollection<T>> AddRange(IEnumerable<T> entities)
        {
            try
            {
                await _context.AddRangeAsync(entities);
                await _context.SaveChangesAsync();
                return entities.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in AddRange() Method Repository: {ex.Message}");
                throw ex;
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Update() Method Repository: {ex.Message}");
                throw ex;
            }
        }

        public async Task<IReadOnlyCollection<T>> UpdateRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().UpdateRange(entities);
                await _context.SaveChangesAsync();
                return entities.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in UpdateRange() Method Repository: {ex.Message}");
                throw ex;
            }
        }

        public async Task Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Delete() Method Repository: {ex.Message}");
                throw ex;
            }
        }

        public async Task DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in DeleteRange() Method Repository: {ex.Message}");
                throw ex;
            }
        }
    }    
}