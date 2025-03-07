using EntityClasses.Person;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EntityClasses.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.ClientId).IsRequired();

        builder.Property(r => r.TrainerId).IsRequired();

        builder.Property(r => r.CourtId).IsRequired();

        builder.Property(r => r.Price).IsRequired();

        builder.Property(r => r.StartTime).IsRequired();

        builder.Property(r => r.Length).IsRequired();

        builder.HasOne<Trainer>(r => r.Trainer)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TrainerId)
            .IsRequired();

        builder.HasOne<Court>(r => r.Court)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CourtId)
            .IsRequired();

        builder.HasOne<Client>(r => r.Client)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.ClientId)
            .IsRequired();
    }
}
