using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Services
{
  public class LecturerService : BaseService<Lecturer>, ILecturerService
  {
    private readonly IBaseRepository<Lecturer> _repository;

    public LecturerService(IBaseRepository<Lecturer> repository) : base(repository)
    {
      _repository = repository;
    }

    public override async Task<bool> Update(int id, Lecturer lecturer)
    {
      if (id != lecturer.Id)
      {
        return false;
      }
      var result = await _repository.GetByIdAsync(id);
      if (result == null)
      {
        return false;
      }
      result.Password = lecturer.Password;
      result.AccountName = lecturer.AccountName;
      result.Email = lecturer.Email;
      await _repository.UpdateAsync(result);
      return true;
    }
  }
}