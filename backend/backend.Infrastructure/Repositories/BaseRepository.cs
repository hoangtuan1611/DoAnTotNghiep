using backend.backend.Core.Interfaces;
using backend.backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.backend.Infrastructure.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
      _dbSet = _dbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T model)
    {
      await _dbSet.AddAsync(model);
      await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T model)
    {
      _dbSet.Update(model);
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var model = await GetByIdAsync(id);
      if (model != null)
      {
        _dbSet.Remove(model);
        await _dbContext.SaveChangesAsync();
      }
    }
  }
}