using backend.backend.Core.Entities;

namespace backend.backend.Core.Interfaces.IServices
{
  public interface IUserService : IBaseService<User>
  {
    Task<bool> CreateUser(string username, string password, string teacherCode, string role = "Teacher");
    Task<(string Token, string TeacherCode, string TeacherName)> ValidUser(string username, string password);
  }
}