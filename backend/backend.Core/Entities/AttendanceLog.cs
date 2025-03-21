using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Entities
{
  public class AttendanceLog : IEntity
  {
    public int Id { get; set; }
    public int StudentCount { get; set; }
    public DateTime LogDate { get; set; }
    public TimeSpan LogTime { get; set; }
    public string ImgPath { get; set; }
    public DateTime CreateAt { get; set; }

    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
  }
}