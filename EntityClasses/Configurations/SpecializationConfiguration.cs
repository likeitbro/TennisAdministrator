using EntityClasses.Person;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EntityClasses.Configurations;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.SportId).IsRequired();

        builder.Property(s => s.TrainerId).IsRequired();

        builder.HasOne<Sport>(s => s.Sport)
            .WithMany(s => s.Specializations)
            .HasForeignKey(s => s.SportId)
            .IsRequired();

        builder.HasOne<Trainer>(s => s.Trainer)
            .WithMany(t => t.Specializations)
            .HasForeignKey(s => s.TrainerId)
            .IsRequired();
    }
}
