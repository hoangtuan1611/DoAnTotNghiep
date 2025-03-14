using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using backend.backend.Core.Interfaces.IRepositories;
using backend.backend.Core.Interfaces.IServices;

namespace backend.backend.Core.Services
{
  public class TimeTableService : BaseService<TimeTable>, ITimeTableService
  {
    private readonly ITimeTableRepository _timeTable;

    public TimeTableService(
      IBaseRepository<TimeTable> repository,
      ITimeTableRepository timeTable) : base(repository)
    {
      _timeTable = timeTable;
    }

    public async Task<IEnumerable<TimeTable>> GetTeacher(string id)
    {
      var result = await _timeTable.GetByTeacherIdAsync(id);
      return result;
    }

    public override async Task<IEnumerable<TimeTable>> GetAll()
    {
      return await _timeTable.GetAll();
    }
  }
}