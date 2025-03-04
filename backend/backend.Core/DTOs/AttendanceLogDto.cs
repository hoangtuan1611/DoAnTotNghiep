namespace backend.backend.Core.DTOs
{
  public class AttendanceLogDto
  {
    public int Id { get; set; }
    public int ClassId { get; set; }
    public int StudentCount { get; set; }
    public DateTime TimeLog { get; set; }
    public string ImgPath { get; set; }
  }
}