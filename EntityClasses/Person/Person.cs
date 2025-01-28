using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses.Person;

/// <summary>
/// Abstract class for people (adds firstname and lastname to abstract entity class)
/// </summary>
public abstract class Person: Entity<Person>
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

    protected Person(string firstname, string lastname)
        : base(Guid.NewGuid())
    {
        FirstName = firstname;
        LastName = lastname;
    }
}
