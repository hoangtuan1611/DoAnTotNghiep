using System.Text.Json.Serialization;

namespace backend.backend.Infrastructure.Seeds
{
  public class ScheduleData
  {
    public Metadata Metadata { get; set; }
    public Dictionary<string, Dictionary<string, List<ScheduleItem>>> Schedule { get; set; }
  }

  public class Metadata
  {
    [JsonPropertyName("week_number")]
    public int WeekNumber { get; set; }
    [JsonPropertyName("start_date")]
    public string StartDate { get; set; }
    [JsonPropertyName("end_date")]
    public string EndDate { get; set; }
    [JsonPropertyName("professor_name")]
    public string ProfessorName { get; set; }
  }

  public class ScheduleItem
  {
    [JsonPropertyName("subject")]
    public string Subject { get; set; }
    [JsonPropertyName("class_code")]
    public string ClassCode { get; set; }
    [JsonPropertyName("class_name")]
    public string ClassName { get; set; }
    [JsonPropertyName("period")]
    public string Period { get; set; }
    [JsonPropertyName("period_begin")]
    public int PeriodBegin { get; set; }
    [JsonPropertyName("period_end")]
    public int PeriodEnd { get; set; }
    [JsonPropertyName("time_begin")]
    public string TimeBegin { get; set; }
    [JsonPropertyName("time_end")]
    public string TimeEnd { get; set; }
    [JsonPropertyName("taught_lessons")]
    public string TaughtLessons { get; set; }
    [JsonPropertyName("room")]
    public string Room { get; set; }
    [JsonPropertyName("content")]
    public string Content { get; set; }
  }
}