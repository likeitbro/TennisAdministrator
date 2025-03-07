using EntityClasses.Person;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EntityClasses.Configurations;

public class TrainerTypeConfiguration : IEntityTypeConfiguration<TrainerType>
{
    public void Configure(EntityTypeBuilder<TrainerType> builder)
    {
        builder.HasKey(tt => tt.Id);

        builder.Property(tt => tt.Id).HasColumnName("Id");

        builder.HasIndex(tt => tt.Name).IsUnique();

        builder.Property(tt => tt.Name).IsRequired().HasMaxLength(50);
    }
}
