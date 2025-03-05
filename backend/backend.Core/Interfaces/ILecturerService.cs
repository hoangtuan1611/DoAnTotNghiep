using backend.backend.Core.Entities;

namespace backend.backend.Core.Interfaces
{
  public interface ILecturerService : IBaseService<Lecturer>
  {
    Task<bool> ValidateUser(string username, string password);
  }
}