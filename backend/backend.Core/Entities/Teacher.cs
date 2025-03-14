using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Entities
{
  public class Teacher : IEntity
  {
    public int Id { get; set; }
    public string TeacherCode { get; set; }
    public string TeacherName { get; set; }

    public User User { get; set; }
    public ICollection<TimeTable> TimeTables { get; set; }
  }
}