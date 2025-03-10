using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses.Sales;

public class Product: Entity<Product>
{
    private string _name;

    public string Name
    {
        get => _name;
        protected set => _name = value.Throw()
            .IfNullOrWhiteSpace(n => n);
    }

    private Guid _productTypeId;

    public Guid ProductTypeId
    {
        get => _productTypeId;
        set => _productTypeId = value.Throw()
            .IfNull(ti => ti);
    }

    private float _price;

    public float Price
    {
        get => _price;
        protected set => _price = value.Throw()
            .IfNull(p => p)
            .IfNegativeOrZero(p => p);
    }

    private int _quantity;

    public int Quantity
    {
        get => _quantity;
        protected set => _quantity = value.Throw()
            .IfNull(q => q)
            .IfNegative(q => q);
    }

    public ProductType ProductType { get; protected set; }

    public List<SaleDetail> SaleDetails { get; protected set; }

    private Product(Guid productTypeId, string name, float price, int quantity)
        :base(Guid.NewGuid())
    {
        ProductTypeId = productTypeId;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public static Product Create(Guid productTypeId, string name, float price, int quantity)
    {
        return new(productTypeId, name, price, quantity);
    }

    public void Update(Guid productTypeId, string name, float price, int quantity)
    {
        ProductTypeId = productTypeId;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}
