using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using backend.backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.backend.Infrastructure.Repositories
{
  public class LecturerRepository : ILecturerRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public LecturerRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Lecturer>> GetAllAsync()
    {
      return await _dbContext.Lecturers.ToListAsync();
    }

    public async Task<Lecturer> GetByIdAsync(int id)
    {
      return await _dbContext.Lecturers.FindAsync(id);
    }

    public async Task AddAsync(Lecturer lecturer)
    {
      await _dbContext.Lecturers.AddAsync(lecturer);
      await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Lecturer lecturer)
    {
      _dbContext.Lecturers.Update(lecturer);
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var lecturer = await GetByIdAsync(id);
      if (lecturer != null)
      {
        _dbContext.Lecturers.Remove(lecturer);
        await _dbContext.SaveChangesAsync();
      }
    }
  }
}