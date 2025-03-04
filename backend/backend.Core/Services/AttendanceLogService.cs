using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Services
{
  public class AttendanceLogService : BaseService<AttendanceLog>, IAttendanceLogService
  {
    public AttendanceLogService(IBaseRepository<AttendanceLog> repository) : base(repository)
    {
    }
  }
}