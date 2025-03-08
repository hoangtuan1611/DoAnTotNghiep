using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Services
{
  public class CourseService : BaseService<Course>, ICourseService
  {
    private readonly IBaseRepository<Course> _repository;

    public CourseService(IBaseRepository<Course> repository) : base(repository)
    {
      _repository = repository;
    }

    public async Task<IEnumerable<Course>> GetCoursesByLecturerId(int id)
    {
      return await _repository.FindAsync(c => c.LecturerId == id);
    }

    public override async Task<bool> Update(int id, Course course)
    {
      if (id != course.Id)
      {
        return false;
      }
      var result = await _repository.GetByIdAsync(id);
      if (result == null)
      {
        return false;
      }
      result.CourseId = course.CourseId;
      result.CourseName = course.CourseName;
      result.LecturerId = course.LecturerId;
      await _repository.UpdateAsync(result);
      return true;
    }
  }
}