using System.Text.Json.Serialization;

namespace TeamPeek.SportsDbClient.Contracts
{
    public class TeamsResponse
    {
        [JsonPropertyName("teams")]
        public List<Team> Teams { get; set; } = [];
    }

    public class Team
    {
        [JsonPropertyName("idTeam")]
        public string? Id { get; set; }
    }
}
