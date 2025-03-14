using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Entities
{
  public class Subject : IEntity
  {
    public int Id { get; set; }
    // public string SubjectCode { get; set; }
    public string SubjectName { get; set; }

    public ICollection<TimeTable> TimeTables { get; set; }
  }
}