using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Domain.Entities;

namespace Api.Data.Mapping
{
  public class UserMap : IEntityTypeConfiguration<UserEntity>
  {
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
      builder.ToTable("User");

      builder.HasKey(p => p.Id);

      builder.HasIndex(p => p.Email).IsUnique();

      builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(60);

      builder.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(100);
    }
  }
}
