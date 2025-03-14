using backend.backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.backend.Infrastructure.Mappings
{
  public class TimeTableMapping : IEntityTypeConfiguration<TimeTable>
  {
    public void Configure(EntityTypeBuilder<TimeTable> builder)
    {
      builder.ToTable("TimeTables");

      builder.HasKey(t => t.Id);

      builder.Property(t => t.DayOfWeek)
        .HasConversion<string>()
        .HasMaxLength(10)
        .IsRequired();

      builder.Property(t => t.TimeOfDay)
        .HasConversion<string>()
        .HasMaxLength(10)
        .IsRequired();

      builder.Property(t => t.PeriodBegin)
        .IsRequired();

      builder.Property(t => t.PeriodEnd)
        .IsRequired();

      builder.Property(t => t.TimeBegin)
        .HasColumnType("TIME")
        .IsRequired();

      builder.Property(t => t.TimeEnd)
        .HasColumnType("TIME")
        .IsRequired();

      builder.Property(t => t.Room)
        .HasMaxLength(15)
        .HasColumnType("varchar(15)")
        .IsRequired();

      builder.HasOne(t => t.Schedule)
        .WithMany(t => t.TimeTables)
        .HasForeignKey(t => t.ScheduleId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(t => t.Subject)
        .WithMany(t => t.TimeTables)
        .HasForeignKey(t => t.SubjectId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(t => t.Teacher)
        .WithMany()
        .HasPrincipalKey(t => t.TeacherCode)
        .HasForeignKey(t => t.TeacherCode)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}