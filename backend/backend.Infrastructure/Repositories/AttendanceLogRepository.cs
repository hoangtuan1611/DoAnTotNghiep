using backend.backend.Core.Interfaces.IRepositories;
using backend.backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.backend.Infrastructure.Repositories
{
  public class AttendanceLogRepository : IAttendanceLogRepository
  {
    private readonly ApplicationDbContext _dbcontext;

    public AttendanceLogRepository(ApplicationDbContext dbContext)
    {
      _dbcontext = dbContext;
    }

    public async Task<IEnumerable<object>> GetByScheduleIdAsync(int scheduleId)
    {
      var logs = await _dbcontext.AttendanceLogs
             .Where(a => a.ScheduleId == scheduleId)
             .OrderByDescending(a => a.LogDate)
             .ToListAsync();

      var groupedLogs = logs
          .GroupBy(a => a.LogDate)
          .Select(group => new
          {
            date = group.Key.ToString("dd/MM/yyyy"),
            logData = group.Select(a => new
            {
              studentCount = a.StudentCount,
              logTime = a.LogTime.ToString(@"hh\:mm"),
              imgPath = a.ImgPath
            }).ToList()
          }).ToList();

      return groupedLogs;
    }
  }
}