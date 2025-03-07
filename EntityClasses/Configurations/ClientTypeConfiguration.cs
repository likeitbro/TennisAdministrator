using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EntityClasses.Person;

namespace EntityClasses.Configurations;

public class ClientTypeConfiguration : IEntityTypeConfiguration<ClientType>
{
    public void Configure(EntityTypeBuilder<ClientType> builder)
    {
        builder.HasKey(ct => ct.Id);

        builder.Property(ct => ct.Id).HasColumnName("Id");

        builder.HasIndex(ct => ct.Name).IsUnique();

        builder.Property(ct => ct.Name).IsRequired().HasMaxLength(50);
    }
}
