using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EntityClasses.Tournaments;
using EntityClasses.Person;

namespace EntityClasses.Configurations;

public class TournamentAttendeeConfiguration : IEntityTypeConfiguration<TournamentAttendee>
{
    public void Configure(EntityTypeBuilder<TournamentAttendee> builder)
    {
        builder.HasKey(ta => ta.Id);

        builder.Property(ta => ta.ClientId).IsRequired();

        builder.Property(ta => ta.TournamentId).IsRequired();

        builder.HasOne<Client>(ta => ta.Attendee)
            .WithMany(a => a.Attends)
            .HasForeignKey(ta => ta.ClientId)
            .IsRequired();

        builder.HasOne<Tournament>(ta => ta.Tournament)
            .WithMany(t => t.TournamentAttendees)
            .HasForeignKey(ta => ta.TournamentId)
            .IsRequired();
    }
}
