using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;
using backend.backend.Core.Interfaces.IServices;

namespace backend.backend.Core.Services
{
  public class ClassService : BaseService<Class>, IClassService
  {
    private readonly IBaseRepository<Class> _repository;

    public ClassService(IBaseRepository<Class> repository) : base(repository)
    {
      _repository = repository;
    }

    public async Task<bool> Update(int id, Class model)
    {
      if (id != model.Id)
      {
        return false;
      }
      var result = await _repository.GetByIdAsync(id);
      if (result == null)
      {
        return false;
      }
      result.MaxStudents = model.MaxStudents;
      await _repository.UpdateAsync(result);
      return true;
    }
  }
}