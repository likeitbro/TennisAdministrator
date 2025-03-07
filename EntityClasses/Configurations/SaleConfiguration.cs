using EntityClasses.Sales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EntityClasses.Person;

namespace EntityClasses.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.ClientId).IsRequired();

        builder.Property(s => s.SaleTime).IsRequired();

        builder.Property(s => s.Revenue).IsRequired();

        builder.HasOne<Client>(s => s.Client)
            .WithMany(c => c.Sales)
            .HasForeignKey(s => s.ClientId)
            .IsRequired();
    }
}
