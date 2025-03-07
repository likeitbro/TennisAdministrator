using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EntityClasses.Tournaments;

namespace EntityClasses.Configurations;

public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name).IsRequired().HasMaxLength(100);

        builder.Property(t => t.SportId).IsRequired();

        builder.Property(t => t.Price).IsRequired();

        builder.Property(t => t.Date).IsRequired();

        builder.Property(t => t.Length).IsRequired();

        builder.Property(t => t.Slots).IsRequired();

        builder.HasOne<Sport>(t => t.Sport)
            .WithMany(s => s.Tournaments)
            .HasForeignKey(t => t.SportId)
            .IsRequired();
    }
}
