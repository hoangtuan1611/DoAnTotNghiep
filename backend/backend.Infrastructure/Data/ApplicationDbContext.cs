using backend.backend.Core.Entities;
using backend.backend.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace backend.backend.Infrastructure.Data
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<Lecturer> Lecturers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudyClass> Classes { get; set; }
    public DbSet<AttendanceLog> attendanceLogs { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new LecturerMap());
      modelBuilder.ApplyConfiguration(new CourseMap());
      modelBuilder.ApplyConfiguration(new StudyClassMap());
      modelBuilder.ApplyConfiguration(new AttendanceLogMap());

      base.OnModelCreating(modelBuilder);
    }
  }
}