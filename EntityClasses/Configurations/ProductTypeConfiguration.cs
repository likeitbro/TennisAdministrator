using EntityClasses.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityClasses.Configurations;

public class ProductTypeConfiguration: IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.HasKey(pt => pt.Id);

        builder.Property(pt => pt.Id).HasColumnName("Id");

        builder.HasIndex(pt => pt.Name).IsUnique();

        builder.Property(pt => pt.Name).IsRequired().HasMaxLength(50);
    }
}
