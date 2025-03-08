using backend.backend.Core.Entities;

namespace backend.backend.Core.Interfaces
{
  public interface ICourseService : IBaseService<Course>
  {
    Task<IEnumerable<Course>> GetCoursesByLecturerId(int id);
  }
}