using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EntityClasses.Person;

namespace EntityClasses.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);

        builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);

        builder.Property(c => c.ClientTypeId).IsRequired();

        builder.Property(c => c.Birthday).IsRequired();

        builder.Property(c => c.Phone).IsRequired().HasMaxLength(15);

        builder.HasOne<ClientType>(c => c.ClientType)
            .WithMany(ct => ct.Clients)
            .HasForeignKey(c => c.ClientTypeId)
            .IsRequired();
    }
}
