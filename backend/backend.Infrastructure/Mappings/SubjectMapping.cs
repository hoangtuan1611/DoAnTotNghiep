using backend.backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.backend.Infrastructure.Mappings
{
  public class SubjectMapping : IEntityTypeConfiguration<Subject>
  {
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
      builder.ToTable("Subjects");

      builder.HasKey(s => s.Id);

      // builder.Property(s => s.SubjectCode)
      //   .HasMaxLength(50)
      //   .HasColumnType("varchar(50)")
      //   .IsRequired();

      // builder.HasIndex(s => s.SubjectCode)
      //   .IsUnique();

      builder.Property(s => s.SubjectName)
        .HasMaxLength(255)
        .IsRequired();
    }
  }
}