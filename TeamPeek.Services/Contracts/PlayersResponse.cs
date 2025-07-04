using System.Text.Json.Serialization;

namespace TeamPeek.SportsDbClient.Contracts
{
    public class PlayersResponse
    {
        [JsonPropertyName("player")]
        public List<PlayerDetails> Players { get; set; } = [];
    }
}
