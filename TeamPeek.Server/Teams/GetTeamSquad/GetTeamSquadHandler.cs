using MediatR;
using TeamPeek.SportsDbClient;
using TeamPeek.SportsDbClient.Contracts;

namespace TeamPeek.Server.Teams.GetTeamSquad
{
    public class GetTeamSquadRequest : IRequest<SquadResponse>
    {
        public string? Search { get; set; }
    }

    public class GetTeamSquadHandler(ISportsDbClient apiClient) : IRequestHandler<GetTeamSquadRequest, SquadResponse>
    {
        private readonly Dictionary<string, string> _nicknameToTeam = new(StringComparer.OrdinalIgnoreCase)
        {
            { "The Hammers", "West Ham United" },
            { "The Irons", "West Ham United" },
            { "The Red Devils", "Manchester United" },
            { "United", "Manchester United" },
            { "The Gunners", "Arsenal" },
            { "The Blues", "Chelsea" },
            { "The Pensioners", "Chelsea" },
            { "The Citizens", "Manchester City" },
            { "The Cityzens", "Manchester City" },
            { "The Sky Blues", "Manchester City" },
            { "The Spurs", "Tottenham Hotspur" },
            { "Spurs", "Tottenham Hotspur" },
            { "The Lilywhites", "Tottenham Hotspur" },
            { "The Magpies", "Newcastle United" },
            { "Toon Army", "Newcastle United" },
            { "The Geordies", "Newcastle United" },
            { "The Eagles", "Crystal Palace" },
            { "The Glaziers", "Crystal Palace" },
            { "The Bees", "Brentford" },
            { "The Seagulls", "Brighton & Hove Albion" },
            { "The Albion", "Brighton & Hove Albion" },
            { "The Cherries", "AFC Bournemouth" },
            { "The Toffees", "Everton" },
            { "The People's Club", "Everton" },
            { "The School of Science", "Everton" },
            { "The Cottagers", "Fulham" },
            { "The Saints", "Southampton" },
            { "The Foxes", "Leicester City" },
            { "The Villans", "Aston Villa" },
            { "The Villa", "Aston Villa" },
            { "The Lions", "Aston Villa" },
            { "The Garibaldis", "Nottingham Forest" },
            { "The Reds", "Nottingham Forest" },
            { "Tricky Trees", "Nottingham Forest" },
            { "Forest", "Nottingham Forest" },
            { "The Tractor Boys", "Ipswich Town" },
            { "Town", "Ipswich Town" }
        };

        public async Task<SquadResponse> Handle(GetTeamSquadRequest request, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(request.Search))
            {
                return new SquadResponse { Success = false, Error = $"Search text should be provided" };
            }

            var officialName = MapToOfficialTeamName(request.Search);
            var teamId = await apiClient.GetTeamIdAsync(officialName, token);
            if (string.IsNullOrWhiteSpace(teamId))
            {
                return new SquadResponse { Success = false, Error = $"Team '{officialName}' not found." };
            }

            var players = await apiClient.GetSquadPlayersAsync(teamId, token);
            if (players == null)
            {
                return new SquadResponse { Success = false, Error = "Could not fetch squad information." };
            }

            return new SquadResponse { Success = true, Players = players.Select(MapToPlayerInfo).ToList() };
        }

        private string MapToOfficialTeamName(string input)
        {
            return _nicknameToTeam.TryGetValue(input, out var officialName) ? officialName : input;
        }

        private PlayerInfo MapToPlayerInfo(PlayerDetails dto)
        {
            return new PlayerInfo
            {
                Id = dto.Id,
                Name = dto.Name,
                DateOfBirth = dto.DateBorn,
                Position = dto.Position,
                ProfilePicture = dto.ProfileUrl
            };
        }
    }
}
