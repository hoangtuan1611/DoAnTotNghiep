using backend.backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.backend.Infrastructure.Mappings
{
  public class LecturerMap : IEntityTypeConfiguration<Lecturer>
  {
    public void Configure(EntityTypeBuilder<Lecturer> builder)
    {
      builder.ToTable("Lecturer");

      builder.HasKey(l => l.Id);

      builder.Property(l => l.Username)
        .HasMaxLength(50)
        .IsRequired()
        .HasColumnType("varchar(50)");

      builder.Property(l => l.Password)
        .HasMaxLength(50)
        .IsRequired()
        .HasColumnType("varchar(50)");

      builder.Property(l => l.AccountName)
        .HasMaxLength(100)
        .IsRequired();

      builder.Property(l => l.Email)
        .HasMaxLength(100)
        .HasColumnType("varchar(100)");
    }
  }
}
