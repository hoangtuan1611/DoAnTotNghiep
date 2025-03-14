namespace backend.backend.Core.DTOs
{
  public class TimeTableDto
  {
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOfDay TimeOfDay { get; set; }
    public int PeriodBegin { get; set; }
    public int PeriodEnd { get; set; }
    public string TimeBegin { get; set; }
    public string TimeEnd { get; set; }
    public string Room { get; set; }
    public string TeacherCode { get; set; }
    public ScheduleDto Schedule { get; set; }
    public SubjectDto Subject { get; set; }
  }

  public enum TimeOfDay
  {
    Morning,
    Afternoon,
    Evening
  }
}