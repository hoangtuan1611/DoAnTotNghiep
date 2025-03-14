using backend.backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.backend.Infrastructure.Mappings
{
  public class UserMapping : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("Users");

      builder.HasKey(u => u.Id);

      builder.Property(u => u.TeacherCode)
        .HasMaxLength(15)
        .HasColumnType("varchar(15)")
        .IsRequired();

      builder.HasIndex(u => u.TeacherCode)
        .IsUnique();

      builder.Property(u => u.Username)
        .HasMaxLength(50)
        .HasColumnType("varchar(50)")
        .IsRequired();

      builder.HasIndex(u => u.Username)
        .IsUnique();

      builder.Property(u => u.PasswordHash)
        .HasMaxLength(255)
        .HasColumnType("varchar(255)")
        .IsRequired();

      builder.Property(u => u.Role)
        .HasMaxLength(50)
        .HasColumnType("varchar(50)")
        .HasDefaultValue("Teacher")
        .IsRequired();
    }
  }
}