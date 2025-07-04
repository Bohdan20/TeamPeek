namespace TeamPeek.Server.Teams.GetTeamSquad
{
    public class SquadResponse
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public List<PlayerInfo> Players { get; set; } = [];
    }
} 