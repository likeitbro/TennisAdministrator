using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses;

public class Court : Entity<Court>
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

    private string _description;

    public string Description
    {
        get => _description;
        protected set
        {
            _description = value.Throw()
                .IfNullOrWhiteSpace(d => d);
        }
    }

    private float _price;

    public float Price
    {
        get => _price;
        protected set => _price = value.Throw()
            .IfNull(p => p)
            .IfNegativeOrZero(p => p);
    }

    protected Court(string name, string description, float price)
        : base(Guid.NewGuid())
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public static Court Create(string name, string description, float price)
    {
        return new(name, description, price);
    }

    public void Update(string name, string description, float price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
}
