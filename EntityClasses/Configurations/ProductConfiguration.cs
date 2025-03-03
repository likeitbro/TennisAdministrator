using EntityClasses.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityClasses.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.TypeId).IsRequired();

        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

        builder.Property(p => p.Price).IsRequired();

        builder.Property(p => p.Quantity).IsRequired();

        builder.HasOne<ProductType>(p => p.ProductType)
            .WithMany(pt => pt.Products)
            .HasForeignKey(p => p.TypeId)
            .IsRequired();
    }
}
