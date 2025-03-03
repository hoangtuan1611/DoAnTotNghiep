using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Entities
{
  public class Lecturer : IEntity
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string AccountName { get; set; }
    public string Email { get; set; }

    public ICollection<Course> Courses { get; set; }
    public ICollection<StudyClass> Classes { get; set; }
  }
}
