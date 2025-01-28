using Throw;

namespace EntityClasses.Abstractions;

/// <summary>
/// Abstract class for people (adds firstname and lastname to abstract entity class)
/// </summary>
public abstract class Person : Entity<Person>
{
    private string _firstname;

    public string FirstName
    {
        get => _firstname;
        protected set
        {
            _firstname = value.Throw()
                .IfNullOrWhiteSpace(n => n);
        }
    }

    private string _lastname;

    public string LastName
    {
        get => _lastname;
        protected set
        {
            _lastname = value.Throw()
                .IfNullOrWhiteSpace(n => n);
        }
    }

    private DateOnly _birthday;

    public DateOnly Birthday
    {
        get => _birthday;
        protected set
        {
            _birthday = value.Throw()
                .IfNull(bd => bd);
        }
    }

    private string _phone;

    public string Phone
    {
        get => _phone;
        protected set
        {
            _phone = value.Throw()
                .IfNullOrWhiteSpace(p => p);
        }
    }

    protected Person()
    {

    }

    protected Person(
        string firstname,
        string lastname,
        DateOnly birthday,
        string phone)
        : base(Guid.NewGuid())
    {
        FirstName = firstname;
        LastName = lastname;
        Birthday = birthday;
        Phone = phone;
    }
}