using backend.backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.backend.Infrastructure.Mappings
{
  public class StudyClassMap : IEntityTypeConfiguration<StudyClass>
  {
    public void Configure(EntityTypeBuilder<StudyClass> builder)
    {
      builder.ToTable("Class");

      builder.HasKey(c => c.Id);

      builder.Property(c => c.ClassId)
        .HasMaxLength(10)
        .HasColumnType("varchar(10)")
        .IsRequired();

      builder.Property(c => c.MaxStudents)
        .IsRequired();

      builder.HasOne(c => c.Lecturer)
        .WithMany(l => l.Classes)
        .HasForeignKey(c => c.LecturerId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasMany(c => c.Courses)
        .WithMany(c => c.Classes)
         .UsingEntity<Dictionary<string, object>>(
        "ClassCourse",
        j => j.HasOne<Course>()
              .WithMany()
              .HasForeignKey("CourseId")
              .OnDelete(DeleteBehavior.NoAction),
        j => j.HasOne<StudyClass>()
              .WithMany()
              .HasForeignKey("ClassId")
              .OnDelete(DeleteBehavior.Cascade));
    }
  }
}