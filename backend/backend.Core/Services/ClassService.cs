using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Services
{
  public class ClassService : BaseService<StudyClass>, IClassService
  {
    private readonly IBaseRepository<StudyClass> _repository;

    public ClassService(IBaseRepository<StudyClass> repository) : base(repository)
    {
      _repository = repository;
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
  }
}