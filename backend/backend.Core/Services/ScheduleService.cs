using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using backend.backend.Core.Interfaces.IServices;

namespace backend.backend.Core.Services
{
  public class ScheduleService : BaseService<Schedule>, IScheduleService
  {
    public ScheduleService(IBaseRepository<Schedule> repository) : base(repository)
    {
    }
  }
}