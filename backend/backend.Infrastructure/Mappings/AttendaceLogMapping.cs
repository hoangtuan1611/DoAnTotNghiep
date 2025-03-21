using backend.backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.backend.Infrastructure.Mappings
{
  public class AttendaceLogMapping : IEntityTypeConfiguration<AttendanceLog>
  {
    public void Configure(EntityTypeBuilder<AttendanceLog> builder)
    {
      builder.ToTable("AttendanceLogs");

      builder.HasKey(a => a.Id);

      builder.Property(a => a.StudentCount)
        .IsRequired();

      builder.Property(a => a.LogDate)
        .HasColumnType("DATE")
        .IsRequired();

      builder.Property(a => a.LogTime)
        .HasColumnType("TIME")
        .IsRequired();

      builder.Property(a => a.ImgPath)
        .HasMaxLength(500)
        .IsUnicode(false);

      builder.Property(a => a.CreateAt)
        .HasColumnType("DATETIME")
        .HasDefaultValueSql("GETDATE()");

      builder.HasOne(a => a.Schedule)
                .WithMany()
                .HasForeignKey(a => a.ScheduleId)
                .OnDelete(DeleteBehavior.Cascade);
    }
  }
}