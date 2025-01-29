using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses;

public class Sport: Entity<Sport>
{
    private string _name;

    public string Name
    {
        get => _name;
        set => _name = value.Throw()
            .IfNullOrWhiteSpace(n => n);
    }

    public Sport(string name)
        :base(Guid.NewGuid())
    {
        Name = name;
    }

    public static Sport Create(string name)
    {
        return new(name);
    }

    public void Update(string name)
    {
        Name = name;
    }
}
