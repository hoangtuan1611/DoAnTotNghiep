using backend.backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.backend.Infrastructure.Mappings
{
  public class ScheduleMapping : IEntityTypeConfiguration<Schedule>
  {
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
      builder.ToTable("Schedules");

      builder.HasKey(s => s.Id);

      builder.Property(s => s.WeekNum)
        .IsRequired();

      builder.Property(s => s.StartDay)
        .HasColumnType("datetime2(7)")
        .HasDefaultValueSql("GETDATE()")
        .IsRequired();

      builder.Property(s => s.EndtDay)
        .HasColumnType("datetime2(7)")
        .HasDefaultValueSql("GETDATE()")
        .IsRequired();

      builder.HasOne(s => s.Class)
        .WithMany(s => s.Schedules)
        .HasForeignKey(s => s.ClassId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}