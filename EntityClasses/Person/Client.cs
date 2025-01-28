using Throw;
using EntityClasses.Abstractions;
using System.Runtime.CompilerServices;

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
