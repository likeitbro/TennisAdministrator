using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EntityClasses.Configurations;

public class SportConfiguration : IEntityTypeConfiguration<Sport>
{
    public void Configure(EntityTypeBuilder<Sport> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id");

        builder.HasIndex(s => s.Name).IsUnique();

        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
    }
}
