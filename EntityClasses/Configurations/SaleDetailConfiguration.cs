using EntityClasses.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityClasses.Configurations;

public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
{
    public void Configure(EntityTypeBuilder<SaleDetail> builder)
    {
        builder.HasKey(sd => sd.Id);

        builder.Property(sd => sd.ProductId).IsRequired();

        builder.Property(sd => sd.SaleId).IsRequired();

        builder.Property(sd => sd.Count).IsRequired();

        builder.HasOne<Product>(sd => sd.Product)
            .WithMany(p => p.SaleDetails)
            .HasForeignKey(sd => sd.ProductId)
            .IsRequired();

        builder.HasOne<Sale>(sd => sd.Sale)
            .WithMany(s => s.SaleDetails)
            .HasForeignKey(sd => sd.SaleId)
            .IsRequired();
    }
}
