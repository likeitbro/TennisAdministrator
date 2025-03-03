using EntityClasses.Abstractions;
using EntityClasses.Tournaments;
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

    public List<Tournament> Tournaments { get; protected set; }

    public List<Specialization> Specializations { get; protected set; }

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
