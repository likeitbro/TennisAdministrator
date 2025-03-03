using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses.Sales;

public class ProductType : Entity<ProductType>
{
    private string _name;

    public string Name
    {
        get => _name;
        protected set
        {
            _name = value.Throw()
                .IfNullOrWhiteSpace(n => n);
        }
    }

    public List<Product> Products { get; protected set; }

    protected ProductType(string name)
        : base(Guid.NewGuid())
    {
        Name = name;
    }

    public static ProductType Create(string name)
    {
        return new(name);
    }

    public void Update(string name)
    {
        Name = name;
    }
}
