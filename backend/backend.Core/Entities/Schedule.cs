using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Entities
{
  public class Schedule : IEntity
  {
    public int Id { get; set; }
    public int WeekNum { get; set; }
    public DateTime StartDay { get; set; }
    public DateTime EndtDay { get; set; }

    public int ClassId { get; set; }
    public Class Class { get; set; }

    public ICollection<TimeTable> TimeTables { get; set; }
  }
}