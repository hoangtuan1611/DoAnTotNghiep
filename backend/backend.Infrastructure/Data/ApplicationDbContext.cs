using backend.backend.Core.Entities;
using backend.backend.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace backend.backend.Infrastructure.Data
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<Class> Classes { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TimeTable> TimeTables { get; set; }
    public DbSet<AttendanceLog> AttendanceLogs { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ClassMapping());
      modelBuilder.ApplyConfiguration(new ScheduleMapping());
      modelBuilder.ApplyConfiguration(new SubjectMapping());
      modelBuilder.ApplyConfiguration(new TeacherMapping());
      modelBuilder.ApplyConfiguration(new TimeTableMapping());
      modelBuilder.ApplyConfiguration(new UserMapping());
      modelBuilder.ApplyConfiguration(new AttendaceLogMapping());

      base.OnModelCreating(modelBuilder);
    }
  }
}