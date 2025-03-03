using backend.backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.backend.Infrastructure.Mappings
{
  public class AttendanceLogMap : IEntityTypeConfiguration<AttendanceLog>
  {
    public void Configure(EntityTypeBuilder<AttendanceLog> builder)
    {
      builder.ToTable("AttendanceLog");

      builder.HasKey(a => a.Id);

      builder.Property(a => a.TimeLog)
        .HasColumnType("datetime2(7)")
        .HasDefaultValueSql("GETDATE()")
        .IsRequired();

      builder.Property(a => a.StudentCount)
        .IsRequired();

      builder.HasOne(a => a.StudyClass)
        .WithMany(c => c.AttendanceLog)
        .HasForeignKey(a => a.ClassId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasIndex(a => new { a.ClassId, a.TimeLog })
        .IsUnique();
    }
  }
}