using Throw;
using EntityClasses.Sales;
using EntityClasses.Tournaments;

namespace EntityClasses.Person;

public class Client : EntityClasses.Abstractions.Person
{
    private Guid _clientTypeId;

    public Guid ClientTypeId
    {
        get => _clientTypeId;
        protected set =>
            _clientTypeId = value.Throw()
                .IfNull(cti => cti);
    }

    public ClientType ClientType { get; protected set; }

    public List<Sale> Sales { get; protected set; }

    public List<Reservation> Reservations { get; protected set; }

    public List<TournamentAttendee> Attends { get; protected set; }

    private Client() { }

    protected Client(string firstname, string lastname, DateOnly birthday, string phone, Guid clientTypeId)
        :base(firstname, lastname, birthday, phone)
    {
        ClientTypeId = clientTypeId;
    }

    public static Client Create(string firstname, string lastname, DateOnly birthday, string phone, Guid clientTypeId)
    {
        return new(firstname, lastname, birthday, phone, clientTypeId);
    }

    public void Update(string firstname, string lastname, DateOnly birthday, string phone, Guid clientTypeId)
    {
        FirstName = firstname;
        LastName = lastname;
        Birthday = birthday;
        Phone = phone;
        ClientTypeId = clientTypeId;
    }
}
