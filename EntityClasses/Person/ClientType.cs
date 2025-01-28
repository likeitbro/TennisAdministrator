using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses.Person;

public class ClientType: Entity<ClientType>
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

    protected ClientType(string name)
        :base(Guid.NewGuid())
    {
        Name = name;
    }

    public static ClientType Create(string name)
    {
        return new(name);
    }

    public void Update(string name)
    {
        Name = name;
    }
}
