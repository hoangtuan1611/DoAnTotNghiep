using backend.backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.backend.Infrastructure.Mappings
{
  public class TeacherMapping : IEntityTypeConfiguration<Teacher>
  {
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
      builder.ToTable("Teachers");

      builder.HasKey(t => t.Id);

      builder.Property(t => t.TeacherCode)
        .HasMaxLength(15)
        .HasColumnType("varchar(15)")
        .IsRequired();

      builder.HasIndex(t => t.TeacherCode)
        .IsUnique();

      builder.Property(t => t.TeacherCode)
        .HasMaxLength(255)
        .IsRequired();

      builder.HasOne(t => t.User)
        .WithOne(t => t.Teacher)
        .HasForeignKey<User>(t => t.TeacherCode)
        .HasPrincipalKey<Teacher>(t => t.TeacherCode)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}