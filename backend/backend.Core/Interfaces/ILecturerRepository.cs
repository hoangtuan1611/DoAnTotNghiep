using backend.backend.Core.Entities;

namespace backend.backend.Core.Interfaces
{
  public interface ILecturerRepository
  {
    Task<IEnumerable<Lecturer>> GetAllAsync();
    Task<Lecturer> GetByIdAsync(int id);
    Task AddAsync(Lecturer lecturer);
    Task UpdateAsync(Lecturer lecturer);
    Task DeleteAsync(int id);
  }
}