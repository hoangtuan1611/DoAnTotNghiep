using backend.backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.backend.Infrastructure.Mappings
{
  public class ClassMapping : IEntityTypeConfiguration<Class>
  {
    public void Configure(EntityTypeBuilder<Class> builder)
    {
      builder.ToTable("Classes");

      builder.HasKey(c => c.Id);

      builder.Property(c => c.ClassCode)
        .HasMaxLength(20)
        .HasColumnType("varchar(20)")
        .IsRequired();

      builder.HasIndex(c => c.ClassCode)
        .IsUnique();

      builder.Property(c => c.ClassName)
        .HasMaxLength(100)
        .IsRequired();
    }
  }
}