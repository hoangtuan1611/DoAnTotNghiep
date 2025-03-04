using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Entities
{
  public class StudyClass : IEntity
  {
    public int Id { get; set; }
    public string ClassId { get; set; }
    public int MaxStudents { get; set; }

    public ICollection<Course> Courses { get; set; }
    public ICollection<AttendanceLog> AttendanceLog { get; set; }
  }
}