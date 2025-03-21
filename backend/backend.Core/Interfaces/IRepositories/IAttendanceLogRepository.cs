namespace backend.backend.Core.Interfaces.IRepositories
{
  public interface IAttendanceLogRepository
  {
    Task<IEnumerable<object>> GetByScheduleIdAsync(int scheduleId);
  }
}