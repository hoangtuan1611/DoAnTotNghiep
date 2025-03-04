using backend.backend.Core.Interfaces;

namespace backend.backend.Core.Entities
{
  public class AttendanceLog : IEntity
  {
    public int Id { get; set; }
    public DateTime TimeLog { get; set; }
    public int StudentCount { get; set; }
    public string ImgPath { get; set; }

    public int ClassId { get; set; }
    public StudyClass StudyClass { get; set; }
  }
}