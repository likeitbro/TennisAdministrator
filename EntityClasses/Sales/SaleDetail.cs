using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses.Sales;

public class SaleDetail: Entity<SaleDetail>
{
    private Guid _saleId;

    public Guid SaleId
    {
        get => _saleId;
        set => _saleId = value.Throw()
            .IfNull(si => si);
    }

    private Guid _productId;

    public Guid ProductId
    {
        get => _productId;
        set => _productId = value.Throw()
            .IfNull(pi => pi);
    }

    private int _count;

    public int Count
    {
        get => _count;
        set => _count = value.Throw()
            .IfNull(c => c)
            .IfNegative(c => c);
    }

    private SaleDetail(Guid saleId, Guid productId, int count)
        :base(Guid.NewGuid())
    {
        SaleId = saleId;
        ProductId = productId;
        Count = count;
    }

    public static SaleDetail Create(Guid saleId, Guid productId, int count)
    {
        return new(saleId, productId, count);
    }

    public void Update(Guid saleId, Guid productId, int count)
    {
        SaleId = saleId;
        ProductId = productId;
        Count = count;
    }
}
