using EntityClasses.Abstractions;
using EntityClasses.Person;
using Throw;

namespace EntityClasses;

public class Specialization: Entity<Specialization>
{
    private Guid _trainerId;

    public Guid TrainerId
    {
        get => _trainerId;
        protected set => _trainerId = value.Throw()
            .IfNull(ti => ti);
    }

    private Guid _sportId;

    public Guid SportId
    {
        get => _sportId;
        protected set => _sportId = value.Throw()
            .IfNull(si => si);
    }

    public Trainer Trainer { get; protected set; }

    public Sport Sport { get; protected set; }

    private Specialization(Guid trainerId, Guid sportId)
        : base(Guid.NewGuid())
    {
        TrainerId = trainerId;
        SportId = sportId;
    }

    public static Specialization Create(Guid trainerId, Guid sportId)
    {
        return new(trainerId, sportId);
    }

    public void Update(Guid trainerId, Guid sportId)
    {
        TrainerId = trainerId;
        SportId = sportId;
    }
}
