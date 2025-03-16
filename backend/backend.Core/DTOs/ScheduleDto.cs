namespace backend.backend.Core.DTOs
{
  public class ScheduleDto
  {
    public int Id { get; set; }
    public int WeekNum { get; set; }
    public DateTime StartDay { get; set; }
    public DateTime EndDay { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
  }
}