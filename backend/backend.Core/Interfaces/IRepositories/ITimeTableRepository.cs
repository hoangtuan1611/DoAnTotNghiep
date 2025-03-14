using backend.backend.Core.Entities;

namespace backend.backend.Core.Interfaces.IRepositories
{
  public interface ITimeTableRepository : IBaseRepository<TimeTable>
  {
    Task<IEnumerable<TimeTable>> GetAll();
    Task<IEnumerable<TimeTable>> GetByTeacherIdAsync(string teacherId);
  }
}