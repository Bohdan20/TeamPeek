using System.Text.Json;
using TeamPeek.SportsDbClient.Contracts;

namespace TeamPeek.SportsDbClient
{
    public class SportsDbClient : ISportsDbClient
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://www.thesportsdb.com/api/v1/json/123/";
        private const string LastSeason = "2024-2025";

        public SportsDbClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string?> GetTeamIdAsync(string teamName, CancellationToken token = default)
        {
            var response = await _client.GetAsync($"{BaseUrl}searchteams.php?t={Uri.EscapeDataString(teamName)}", token);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(token);

            var teams = JsonSerializer.Deserialize<TeamsResponse>(json);
            return teams?.Teams.SingleOrDefault()?.Id;
        }

        public async Task<List<PlayerDetails>> GetSquadPlayersAsync(string teamId, CancellationToken token = default)
        {
            var response = await _client.GetAsync($"{BaseUrl}lookup_all_players.php?id={teamId}&s={LastSeason}", token);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<PlayersResponse>(json)?.Players ?? [];
        } 
    }
} 