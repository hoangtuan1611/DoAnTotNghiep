using System.Linq.Expressions;

namespace backend.backend.Core.Interfaces
{
  public interface IBaseRepository<T> where T : class
  {
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T model);
    Task UpdateAsync(T model);
    Task DeleteAsync(int id);
    Task SaveAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
  }
}