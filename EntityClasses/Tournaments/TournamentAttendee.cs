using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses.Tournaments;

public class TournamentAttendee: Entity<TournamentAttendee>
{
    private Guid _clientId;

    public Guid ClientId
    {
        get => _clientId;
        set => _clientId = value.Throw()
            .IfNull(ci => ci);
    }

    private Guid _tournamentId;

    public Guid TournamentId
    {
        get => _tournamentId;
        set => _tournamentId = value.Throw()
            .IfNull(ti => ti);
    }

    private TournamentAttendee(Guid clientId, Guid tournamentId)
        :base(Guid.NewGuid())
    {
        ClientId = clientId;
        TournamentId = tournamentId;
    }

    public static TournamentAttendee Create(Guid clientId, Guid tournamentId)
    {
        return new(clientId, tournamentId);
    }

    public void Update(Guid clientId, Guid tournamentId)
    {
        ClientId = clientId;
        TournamentId = tournamentId;
    }
}
