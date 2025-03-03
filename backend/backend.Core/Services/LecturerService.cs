using backend.backend.Core.Entities;
using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Services
{
  public class LecturerService : ILecturerService
  {
    private readonly ILecturerRepository _repository;

    public LecturerService(ILecturerRepository repository)
    {
      _repository = repository;
    }

    public async Task<IEnumerable<Lecturer>> GetAllLecturers()
    {
      return await _repository.GetAllAsync();
    }

    public async Task<Lecturer> GetLecturerById(int id)
    {
      return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> CreateLecturer(Lecturer lecturer)
    {
      await _repository.AddAsync(lecturer);
      return true;
    }

    public async Task<bool> UpdateLecturer(int id, Lecturer lecturer)
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

    public async Task<bool> DeleteLecturer(int id)
    {
      var lecturer = await _repository.GetByIdAsync(id);
      if (lecturer != null)
      {
        await _repository.DeleteAsync(id);
        return true;
      }
      return false;
    }
  }
}