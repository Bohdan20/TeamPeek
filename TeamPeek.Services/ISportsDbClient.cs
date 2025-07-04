namespace TeamPeek.SportsDbClient
{
    public interface ISportsDbClient
    {
        Task<int?> GetTeamIdAsync(string teamName, CancellationToken token = default);
        Task<List<PlayerDetails>> GetSquadPlayersAsync(int teamId, CancellationToken token = default);
    }
} 