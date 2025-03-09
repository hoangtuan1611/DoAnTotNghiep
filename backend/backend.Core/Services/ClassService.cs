using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using backend.backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.backend.Core.Services
{
  public class ClassService : BaseService<StudyClass>, IClassService
  {
    private readonly IBaseRepository<StudyClass> _repository;
    private readonly ApplicationDbContext _context;

    public ClassService(
      IBaseRepository<StudyClass> repository,
      ApplicationDbContext context) : base(repository)
    {
      _repository = repository;
      _context = context;
    }

    public override async Task<bool> Update(int id, StudyClass studyClass)
    {
      if (id != studyClass.Id)
      {
        return false;
      }
      var result = await _repository.GetByIdAsync(id);
      if (result == null)
      {
        return false;
      }
      result.ClassId = studyClass.ClassId;
      result.MaxStudents = studyClass.MaxStudents;
      await _repository.UpdateAsync(result);
      return true;
    }

    public override async Task<bool> Create(StudyClass model)
    {
      var courseCheck = await _repository.GetByIdAsync(model.IdCourse);
      if (courseCheck == null)
      {
        return false;
      }

      await _repository.AddAsync(model);
      await _repository.SaveAsync();

      var studyClass = await _context.Classes
          .Include(c => c.Courses)
          .FirstOrDefaultAsync(c => c.Id == model.Id);

      var course = await _context.Courses
          .Include(c => c.Classes)
          .FirstOrDefaultAsync(c => c.Id == model.IdCourse);

      if (studyClass != null && course != null)
      {
        studyClass.Courses.Add(course);
        await _repository.SaveAsync();
      }

      return true;
    }
  }
}