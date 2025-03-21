using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using backend.backend.Core.Interfaces.IRepositories;
using backend.backend.Core.Interfaces.IServices;

namespace backend.backend.Core.Services
{
  public class AttendanceLogService : BaseService<AttendanceLog>, IAttendanceLogService
  {
    private readonly IAttendanceLogRepository _repository;

    public AttendanceLogService(
      IBaseRepository<AttendanceLog> repository,
      IAttendanceLogRepository attendanceLogRepository) : base(repository)
    {
      _repository = attendanceLogRepository;
    }

    public async Task<IEnumerable<object>> GetByScheduleId(int scheduleId)
    {
      return await _repository.GetByScheduleIdAsync(scheduleId);
    }
  }
}