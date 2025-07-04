using System.Text.Json;

namespace TeamPeek.SportsDbClient
{
    public class SportsDbClient : ISportsDbClient
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://www.thesportsdb.com/api/v1/json/123";
        private const string LastSeason = "2024-2025";

        public SportsDbClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<int?> GetTeamIdAsync(string teamName, CancellationToken token = default)
        {
            var url = $"{BaseUrl}/searchteams.php?t={Uri.EscapeDataString(teamName)}";
            var response = await _client.GetAsync(url, token);
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync(token);
            var doc = JsonDocument.Parse(json);
            if (!doc.RootElement.TryGetProperty("teams", out var teams) || teams.ValueKind != JsonValueKind.Array || teams.GetArrayLength() == 0)
                return null;
            var team = teams[0];
            if (team.TryGetProperty("idTeam", out var idTeamProp) && int.TryParse(idTeamProp.GetString(), out var idTeam))
                return idTeam;
            return null;
        }

        public async Task<List<PlayerDetails>> GetSquadPlayersAsync(int teamId, CancellationToken token = default)
        {
            var url = $"{BaseUrl}/lookup_all_players.php?id={teamId}&s={LastSeason}";
            var response = await _client.GetAsync(url, token);
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync(token);
            using var doc = JsonDocument.Parse(json);
            if (!doc.RootElement.TryGetProperty("player", out var playersArr) || playersArr.ValueKind != JsonValueKind.Array)
                return null;
            return JsonSerializer.Deserialize<List<PlayerDetails>>(playersArr.GetRawText()) ?? [];
        } 
    }
} 