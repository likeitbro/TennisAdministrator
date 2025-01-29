using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses;

public class Specialization: Entity<Specialization>
{
    private Guid _trainerId;

    public Guid TrainerId
    {
        get => _trainerId;
        set => _trainerId = value.Throw()
            .IfNull(ti => ti);
    }

    private Guid _sportId;

    public Guid SportId
    {
        get => _sportId;
        set => _sportId = value.Throw()
            .IfNull(si => si);
    }

    private Specialization(Guid trainerId, Guid sportId)
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
