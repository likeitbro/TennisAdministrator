using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses.Sales;

public class Sale: Entity<Sale>
{
    private Guid _clientId;

    public Guid ClientId
    {
        get => _clientId;
        set => _clientId = value.Throw()
            .IfNull(ci => ci);
    }

    private DateTime _saleTime;

    public DateTime SaleTime
    {
        get => _saleTime;
        set => _saleTime = value.Throw()
            .IfNull(st => st);
    }

    private float _revenue;

    public float Revenue
    {
        get => _revenue;
        set => _revenue = value.Throw()
            .IfNull(r => r)
            .IfNegative(r => r);
    }

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
