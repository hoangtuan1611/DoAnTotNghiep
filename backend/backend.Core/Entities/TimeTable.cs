using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Entities
{
  public class TimeTable : IEntity
  {
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOfDay TimeOfDay { get; set; }
    public int PeriodBegin { get; set; }
    public int PeriodEnd { get; set; }
    public TimeSpan TimeBegin { get; set; }
    public TimeSpan TimeEnd { get; set; }
    public string Room { get; set; }

    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    public string TeacherCode { get; set; }
    public Teacher Teacher { get; set; }
  }

  public enum TimeOfDay
  {
    Morning,
    Afternoon,
    Evening
  }
}