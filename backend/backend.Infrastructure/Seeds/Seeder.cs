using System.Globalization;
using System.Text.Json;
using backend.backend.Core.Entities;
using backend.backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.backend.Infrastructure.Seeds
{
  public class Seeder
  {
    private readonly ApplicationDbContext _dbcontext;

    private string[] roomCode = { "A8.6", "A8.5", "A24.1", "TV1", "TV2", "TV3", "TV4" };

    public Seeder(ApplicationDbContext dbContext)
    {
      _dbcontext = dbContext;
    }

    public async Task SeedDataAsync(string jsonPath, string TeacherCode)
    {
      string jsonData = await File.ReadAllTextAsync(jsonPath);
      var scheduleData = JsonSerializer.Deserialize<ScheduleData>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

      if (scheduleData == null) return;

      foreach (var (day, sessions) in scheduleData.Schedule)
      {
        foreach (var (timeOfDay, subjects) in sessions)
        {
          foreach (var item in subjects)
          {
            if (!roomCode.Contains(item.Room)) continue;

            string classCode = item.ClassCode ?? "Unknown";
            string className = item.ClassName ?? "Unknown";

            var existingClass = await _dbcontext.Classes.FirstOrDefaultAsync(c => c.ClassCode == classCode)
            ?? (await _dbcontext.Classes.AddAsync(new Class { ClassCode = classCode, ClassName = className, MaxStudents = 0 })).Entity;

            await _dbcontext.SaveChangesAsync();

            Console.WriteLine("add class done");

            var existingSchedule = await _dbcontext.Schedules.FirstOrDefaultAsync(s =>
                s.WeekNum == scheduleData.Metadata.WeekNumber &&
                s.ClassId == existingClass.Id);

            if (existingSchedule != null) continue;

            var schedule = new Schedule
            {
              WeekNum = scheduleData.Metadata.WeekNumber,
              StartDay = DateTime.ParseExact(scheduleData.Metadata.StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
              EndDay = DateTime.ParseExact(scheduleData.Metadata.EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
              ClassId = existingClass.Id,
            };

            await _dbcontext.Schedules.AddAsync(schedule);
            await _dbcontext.SaveChangesAsync();

            var subject = await _dbcontext.Subjects.FirstOrDefaultAsync(s => s.SubjectName == item.Subject);
            if (subject == null)
            {
              subject = new Subject { SubjectName = item.Subject };
              _dbcontext.Subjects.Add(subject);
              await _dbcontext.SaveChangesAsync();
            }

            var existingTimetable = await _dbcontext.TimeTables.FirstOrDefaultAsync(t =>
                t.ScheduleId == schedule.Id &&
                t.DayOfWeek == ParseDayOfWeek(day) &&
                t.TimeOfDay == ParseTimeOfDay(timeOfDay) &&
                t.SubjectId == subject.Id &&
                t.PeriodBegin == item.PeriodBegin &&
                t.PeriodEnd == item.PeriodEnd);

            if (existingTimetable != null) continue;

            var timetable = new TimeTable
            {
              ScheduleId = schedule.Id,
              DayOfWeek = ParseDayOfWeek(day),
              TimeOfDay = ParseTimeOfDay(timeOfDay),
              SubjectId = subject.Id,
              TeacherCode = TeacherCode,
              PeriodBegin = item.PeriodBegin,
              PeriodEnd = item.PeriodEnd,
              TimeBegin = TimeSpan.Parse(item.TimeBegin),
              TimeEnd = TimeSpan.Parse(item.TimeEnd),
              Room = item.Room
            };

            _dbcontext.TimeTables.Add(timetable);
            await _dbcontext.SaveChangesAsync();
          }
        }
      }
    }

    private static DayOfWeek ParseDayOfWeek(string day)
    {
      return day switch
      {
        "Thứ 2" => DayOfWeek.Monday,
        "Thứ 3" => DayOfWeek.Tuesday,
        "Thứ 4" => DayOfWeek.Wednesday,
        "Thứ 5" => DayOfWeek.Thursday,
        "Thứ 6" => DayOfWeek.Friday,
        "Thứ 7" => DayOfWeek.Saturday,
        "Chủ nhật" => DayOfWeek.Sunday,
        _ => throw new ArgumentException("Invalid day of week")
      };
    }

    private static TimeOfDay ParseTimeOfDay(string timeOfDay)
    {
      return timeOfDay switch
      {
        "morning" => TimeOfDay.Morning,
        "afternoon" => TimeOfDay.Afternoon,
        "evening" => TimeOfDay.Evening,
        _ => throw new ArgumentException("Invalid time of day")
      };
    }
  }
}