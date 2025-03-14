using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces.IRepositories;
using backend.backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.backend.Infrastructure.Repositories
{
  public class TimeTableRepository : BaseRepository<TimeTable>, ITimeTableRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public TimeTableRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<TimeTable>> GetAll()
    {
      return await _dbContext.TimeTables
        .Include(t => t.Schedule).ThenInclude(t => t.Class)
        .Include(t => t.Subject)
        .ToListAsync();
    }

    public async Task<IEnumerable<TimeTable>> GetByTeacherIdAsync(string teacherId)
    {
      return await _dbContext.TimeTables
        .Include(t => t.Schedule).ThenInclude(t => t.Class)
        .Include(t => t.Subject)
        .Where(t => t.Teacher.TeacherCode == teacherId)
        .ToListAsync();
    }
  }
}