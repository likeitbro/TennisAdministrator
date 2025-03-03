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

    private Product(string name, float price, int quantity)
        :base(Guid.NewGuid())
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public static Product Create(string name, float price, int quantity)
    {
        return new(name, price, quantity);
    }

    public void Update(string name, float price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}
