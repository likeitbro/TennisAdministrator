using EntityClasses.Person;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EntityClasses.Configurations;

public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.TrainerTypeId).IsRequired();

        builder.Property(t => t.FirstName).IsRequired().HasMaxLength(50);

        builder.Property(t => t.LastName).IsRequired().HasMaxLength(50);

        builder.Property(t => t.Birthday).IsRequired();

        builder.Property(t => t.Phone).IsRequired().HasMaxLength(15);

        builder.Property(t => t.Experience).IsRequired();

        builder.Property(t => t.Description).IsRequired().HasMaxLength(500);

        builder.HasOne<TrainerType>(t => t.TrainerType)
            .WithMany(tt => tt.Trainers)
            .HasForeignKey(t => t.TrainerTypeId)
            .IsRequired();
    }
}
