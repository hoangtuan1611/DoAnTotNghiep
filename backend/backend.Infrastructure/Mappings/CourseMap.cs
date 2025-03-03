using backend.backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.backend.Infrastructure.Mappings
{
  public class CourseMap : IEntityTypeConfiguration<Course>
  {
    public void Configure(EntityTypeBuilder<Course> builder)
    {
      builder.ToTable("Course");

      builder.HasKey(c => c.Id);

      builder.Property(c => c.CourseId)
        .HasMaxLength(10)
        .IsRequired()
        .HasColumnType("varchar(10)");

      builder.Property(c => c.CourseName)
        .HasMaxLength(200)
        .IsRequired();

      builder.HasOne(c => c.Lecturer)
        .WithMany(l => l.Courses)
        .HasForeignKey(c => c.LecturerId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
