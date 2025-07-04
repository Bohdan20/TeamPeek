using TeamPeek.SportsDbClient.Contracts;

namespace TeamPeek.SportsDbClient
{
    public interface ISportsDbClient
    {
        Task<string?> GetTeamIdAsync(string teamName, CancellationToken token = default);
        Task<List<PlayerDetails>> GetSquadPlayersAsync(string teamId, CancellationToken token = default);
    }
} 