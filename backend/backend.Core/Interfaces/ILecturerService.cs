using backend.backend.Core.Entities;

namespace backend.backend.Core.Interfaces
{
  public interface ILecturerService : IBaseService<Lecturer>
  {
    Task<bool> UpdateLecturer(int id, Lecturer lecturer);
  }
}