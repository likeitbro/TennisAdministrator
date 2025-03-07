using EntityClasses.Abstractions;
using EntityClasses.Person;
using Throw;

namespace EntityClasses;

public class Reservation : Entity<Reservation>
{
    private Guid _clientId;

    public Guid ClientId
    {
        get => _clientId;
        protected set => _clientId = value.Throw()
            .IfNull(ci => ci);
    }

    // Trainer is nullable due to availability of reservation without trainer
    private Guid? _trainerId;

    public Guid? TrainerId
    {
        get => _trainerId;
        protected set => _trainerId = value;

    }

    private Guid _courtId;

    public Guid CourtId
    {
        get => _courtId;
        protected set => _courtId = value.Throw()
            .IfNull(ci => ci);

    }

    private int _price;

    public int Price
    {
        get => _price;
        protected set => _price = value.Throw()
            .IfNull(p => p)
            .IfNegative(p => p);
    }

    private DateTime _startTime;

    public DateTime StartTime
    {
        get => _startTime;
        protected set => _startTime = value.Throw()
            .IfNull(st => st);
    }

    private TimeOnly _length;

    public TimeOnly Length
    {
        get => _length;
        protected set => _length = value.Throw()
            .IfNull(l => l);
    }

    public Client Client { get; protected set; }

    public Trainer Trainer { get; protected set; }

    public Court Court { get; protected set; }

    private Reservation(Guid clientId, Guid? trainerId, Guid courtId, int price, DateTime startTime, TimeOnly length)
        :base(Guid.NewGuid())
    {
        ClientId = clientId;
        TrainerId = trainerId;
        CourtId = courtId;
        Price = price;
        StartTime = startTime;
        Length = length;
    }

    public static Reservation Create(Guid clientId, Guid? trainerId, Guid courtId, int price, DateTime startTime, TimeOnly length)
    {
        return new(clientId, trainerId, courtId, price, startTime, length);
    }

    public void Update(Guid clientId, Guid? trainerId, Guid courtId, int price, DateTime startTime, TimeOnly length)
    {
        ClientId = clientId;
        TrainerId = trainerId;
        CourtId = courtId;
        Price = price;
        StartTime = startTime;
        Length = length;
    }
}
