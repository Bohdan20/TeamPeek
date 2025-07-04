using MediatR;
using TeamPeek.Server.Teams.GetTeamSquad;
using TeamPeek.SportsDbClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<ISportsDbClient, SportsDbClient>();

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/squad", async (string team, IMediator mediator, CancellationToken token) =>
{
    var result = await mediator.Send(new GetTeamSquadRequest { Search = team }, token);
    return Results.Ok(result);
})
.WithName("Get team's squad")
.Produces<SquadResponse>();

app.MapFallbackToFile("/index.html");

app.Run();
