using System.Text.Json.Serialization;

namespace TeamPeek.SportsDbClient.Contracts
{
    public class PlayerDetails
    {
        [JsonPropertyName("idPlayer")]
        public string? Id { get; set; }
        [JsonPropertyName("strPlayer")]
        public string? Name { get; set; }
        [JsonPropertyName("dateBorn")]
        public string? DateBorn { get; set; }
        [JsonPropertyName("strPosition")]
        public string? Position { get; set; }
        [JsonPropertyName("strCutout")]
        public string? ProfileUrl { get; set; }
    }
} 