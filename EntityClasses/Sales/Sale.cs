using EntityClasses.Abstractions;
using EntityClasses.Person;
using Throw;

namespace EntityClasses.Sales;

public class Sale: Entity<Sale>
{
    private Guid _clientId;

    public Guid ClientId
    {
        get => _clientId;
        protected set => _clientId = value.Throw()
            .IfNull(ci => ci);
    }

    private DateTime _saleTime;

    public DateTime SaleTime
    {
        get => _saleTime;
        protected set => _saleTime = value.Throw()
            .IfNull(st => st);
    }

    private float _revenue;

    public float Revenue
    {
        get => _revenue;
        protected set => _revenue = value.Throw()
            .IfNull(r => r)
            .IfNegative(r => r);
    }

    public List<SaleDetail> SaleDetails { get; protected set; }

    public Client Client { get; protected set; }

    private Sale(Guid clientId, DateTime saleTime, float revenue)
        :base(Guid.NewGuid())
    {
        ClientId = clientId;
        SaleTime = saleTime;
        Revenue = revenue;
    }

    public static Sale Create(Guid clientId, DateTime saleTime, float revenue)
    {
        return new(clientId, saleTime, revenue);
    }

    public void Update(Guid clientId, DateTime saleTime, float revenue)
    {
        ClientId = clientId;
        SaleTime = saleTime;
        Revenue = revenue;
    }
}
