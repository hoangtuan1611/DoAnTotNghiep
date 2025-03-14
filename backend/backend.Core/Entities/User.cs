using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Entities
{
  public class User : IEntity
  {
    public int Id { get; set; }
    public string TeacherCode { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }

    public Teacher Teacher { get; set; }
  }
}