namespace backend.backend.Core.DTOs
{
  public class AttendaceLogDto
  {
    public int Id { get; set; }
    public int StudentCount { get; set; }
    public DateTime LogDate { get; set; }
    public TimeSpan LogTime { get; set; }
    public string ImgPath { get; set; }
    public DateTime CreateAt { get; set; }
  }
}