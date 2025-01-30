using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses.Tournaments;

public class Tournament: Entity<Tournament>
{
    private string _name;

    public string Name
    {
        get => _name;
        set => _name = value.Throw()
            .IfNullOrWhiteSpace(n => n);
    }

    private Guid _sportId;

    public Guid SportId
    {
        get => _sportId;
        set => _sportId = value.Throw()
            .IfNull(s => s);
    }

    public Sport Sport { get; protected set; }

    private float _price;

    public float Price
    {
        get => _price;
        set => _price = value.Throw()
            .IfNull(p => p)
            .IfNegative(p => p);
    }

    private DateTime _date;

    public DateTime Date
    {
        get => _date;
        set => _date = value.Throw()
            .IfNull(d => d);
    }

    private TimeOnly _length;

    public TimeOnly Length
    {
        get => _length;
        set => _length = value.Throw()
            .IfNull(l => l);
    }

    private int _slots;

    public int Slots
    {
        get => _slots;
        set => _slots = value.Throw()
            .IfNull(s => s)
            .IfNegative(s => s);
    }

    private Tournament(string name, Guid sportId, float price, DateTime date, TimeOnly length, int slots)
        :base(Guid.NewGuid())
    {
        Name = name;
        SportId = sportId;
        Price = price;
        Date = date;
        Length = length;
        Slots = slots;
    }

    public static Tournament Create(string name, Guid sportId, float price, DateTime date, TimeOnly length, int slots)
    {
        return new(name, sportId, price, date, length, slots);
    }

    public void Update(string name, Guid sportId, float price, DateTime date, TimeOnly length, int slots)
    {
        Name = name;
        SportId = sportId;
        Price = price;
        Date = date;
        Length = length;
        Slots = slots;
    }
}
