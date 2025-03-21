using backend.backend.Core.Entities;

namespace backend.backend.Core.Interfaces.IServices
{
  public interface IAttendanceLogService : IBaseService<AttendanceLog>
  {
    Task<IEnumerable<object>> GetByScheduleId(int scheduleId);
  }
}