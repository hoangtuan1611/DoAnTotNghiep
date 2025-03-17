using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Entities
{
  public class Class : IEntity
  {
    public int Id { get; set; }
    public string ClassCode { get; set; }
    public string ClassName { get; set; }
    public int MaxStudents { get; set; }

    public ICollection<Schedule> Schedules { get; set; }
  }
}