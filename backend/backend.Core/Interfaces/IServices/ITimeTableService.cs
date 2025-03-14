using backend.backend.Core.Entities;

namespace backend.backend.Core.Interfaces.IServices
{
  public interface ITimeTableService : IBaseService<TimeTable>
  {
    Task<IEnumerable<TimeTable>> GetTeacher(string id);
  }
}