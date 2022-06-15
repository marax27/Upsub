using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Upsub.Server.Api.RealTimeCommunication;

namespace Upsub.Server.Api.Controllers;

internal record BasicLineSeries(IReadOnlyList<double> Data, string Name);

[ApiController]
[Route("[controller]")]
public class ExamplesController : ControllerBase
{
    private readonly IHubContext<DashboardFeedHub> _hubContext;

    public ExamplesController(IHubContext<DashboardFeedHub> hubContext)
    {
        _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var series = new[]
        {
            new BasicLineSeries(GenerateRandom(), "First"),
            new BasicLineSeries(GenerateRandom(), "Other")
        };
        await _hubContext.Clients.All.SendAsync("NewData", series);
        return Ok("Graph posted successfully.");
    }

    private static IReadOnlyList<double> GenerateRandom()
    {
        var pointCount = 120;
        var randomness = new Random();
        var slope = randomness.NextDouble();
        var noise = randomness.NextDouble();

        return Enumerable.Range(1, pointCount)
            .Select(i => slope * i / pointCount + randomness.NextDouble() * noise)
            .ToArray();
    }
}