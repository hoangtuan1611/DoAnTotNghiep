using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Entities
{
  public class Course : IEntity
  {
    public int Id { get; set; }
    public string CourseId { get; set; }
    public string CourseName { get; set; }

    public int LecturerId { get; set; }
    public Lecturer Lecturer { get; set; }

    public ICollection<StudyClass> Classes { get; set; }
  }
}
